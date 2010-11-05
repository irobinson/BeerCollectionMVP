namespace BeerCollectionMVP.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using BeerCollection;
    using BeerCollection.Components.Models;
    using BeerCollection.Components.Presenters;
    using BeerCollection.Data;
    using MbUnit.Framework;
    using Moq;
    using WebFormsMvp;

    [TestFixture]
    public class BeersToDrinkSoonPresenterTests
    {
        private Mock<IViewBeersToDrinkSoon> view;
        private Mock<IBeerRepository> service;
        private BeersToDrinkSoonPresenter presenter;
        private MessageCoordinator messageCoordinator;

        // [MethodName]_[StateUnderTest]_[ExpectedBehavior]

        [SetUp]
        public void SetUp()
        {
           view = new Mock<IViewBeersToDrinkSoon>();
           service = new Mock<IBeerRepository>();
           messageCoordinator = new MessageCoordinator();
        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [Test]
        public void ViewLoad_NoCollectionMessagePublished_LoadsCollectionFromService()
        {
            // Arrange
            view.Setup(v => v.Model).Returns(new BeerCollectionModel());
            service.Setup(x => x.GetBeers()).Returns(new List<Beer>().AsQueryable); 
            presenter = new BeersToDrinkSoonPresenter(view.Object, service.Object) {Messages = messageCoordinator};

            // Act
            view.Raise(x => x.Load += null, null, null);
            presenter.ReleaseView();
            messageCoordinator.Close();

            // Assert
            Assert.IsNotNull(view.Object.Model.BeerCollection);
        }

        [Test]
        public void ViewLoad_CollectionMessagePublished_DoesNotLoadFromService()
        {
            //Arrange
            view.Setup(v => v.Model).Returns(new BeerCollectionModel());

            presenter = new BeersToDrinkSoonPresenter(view.Object, service.Object) {Messages = messageCoordinator};
            var beerList = new List<Beer> {new Beer {BeerId = 1, Name = "Test Beer"}};
            
            //Act
            view.Raise(x => x.Load += null, null, null);
            messageCoordinator.Publish(beerList);
            messageCoordinator.Close();
            presenter.ReleaseView();

            //Assert
            service.Verify(x => x.GetBeers(), Times.Never());
        }

        [Test]
        public void SetModel_ServiceResultHasConsumedBeers_RemovesConsumedBeers()
        {
            //Arrange
            view.Setup(v => v.Model).Returns(new BeerCollectionModel());

            var beer1 = new Beer { BeerId = 1, Name = "Bigfoot", IsConsumed = true };
            var beer2 = new Beer { BeerId = 2, Name = "Yeti", IsConsumed = false };
            var beerList = new List<Beer> { beer1, beer2 };

            service.Setup(s => s.GetBeers()).Returns(beerList.AsQueryable());

            presenter = new BeersToDrinkSoonPresenter(view.Object, service.Object) {Messages = messageCoordinator};

            //Act
            view.Raise(x => x.Load += null, null, null);
            presenter.ReleaseView();
            messageCoordinator.Close();

            //Assert
            Assert.DoesNotContain(view.Object.Model.BeerCollection, beer1);
        }

        [Test]
        public void SetModel_ServiceResultIsGreaterThanThre_ReturnsThreeBeers()
        {
            //Arrange
            view.Setup(v => v.Model).Returns(new BeerCollectionModel());

            var beer1 = new Beer { BeerId = 1, Name = "Bigfoot", IsConsumed = false };
            var beer2 = new Beer { BeerId = 2, Name = "Yeti", IsConsumed = false };
            var beer3 = new Beer { BeerId = 3, Name = "Darkness", IsConsumed = false };
            var beer4 = new Beer { BeerId = 4, Name = "Furious", IsConsumed = false };
            var beerList = new List<Beer> { beer1, beer2, beer3, beer4 };

            service.Setup(s => s.GetBeers()).Returns(beerList.AsQueryable());

            presenter = new BeersToDrinkSoonPresenter(view.Object, service.Object) { Messages = messageCoordinator };

            //Act
            view.Raise(x => x.Load += null, null, null);
            presenter.ReleaseView();
            messageCoordinator.Close();

            //Assert
            Assert.AreEqual(view.Object.Model.BeerCollection.Count, 3);
        }
    }
}