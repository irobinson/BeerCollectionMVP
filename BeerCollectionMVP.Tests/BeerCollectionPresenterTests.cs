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
    public class BeerCollectionPresenterTests
    {
        [Test]
        public void BeerCollection_From_Service_When_No_Message_Published()
        {
            // Arrange
            var view = new Mock<IViewBeersToDrinkSoon>();
            view.Setup(v => v.Model).Returns(new BeerCollectionModel());

            var service = new Mock<IBeerRepository>();
            service.Setup(x => x.GetBeers()).Returns(new List<Beer>().AsQueryable); 

            var presenter = new BeersToDrinkSoonPresenter(view.Object, service.Object);
            var messageCoordinator = new MessageCoordinator();
            presenter.Messages = messageCoordinator;

            // Act
            view.Raise(x => x.Load += null, null, null);
            presenter.ReleaseView();
            messageCoordinator.Close();

            // Assert
            Assert.IsNotNull(view.Object.Model.BeerCollection);
            service.Verify();
        }

        [Test]
        public void BeerCollection_Not_From_Service_When_Published()
        {
            //Arrange
            var view = new Mock<IViewBeersToDrinkSoon>();
            view.Setup(v => v.Model).Returns(new BeerCollectionModel());

            var service = new Mock<IBeerRepository>();

            var presenter = new BeersToDrinkSoonPresenter(view.Object, service.Object);
            var messageCoordinator = new MessageCoordinator();
            presenter.Messages = messageCoordinator;

            //Act
            view.Raise(x => x.Load += null, null, null);
            messageCoordinator.Publish(new Mock<IQueryable<BeerCollectionModel>>());
            messageCoordinator.Close();
            presenter.ReleaseView();

            //Assert
            Assert.IsNotNull(view.Object.Model.BeerCollection);
            service.Verify(x => x.GetBeers(), Times.Never());
        }
    }
}
