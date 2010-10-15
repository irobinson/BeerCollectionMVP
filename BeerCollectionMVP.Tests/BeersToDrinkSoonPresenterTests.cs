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
            var beerList = new List<Beer> {new Beer {BeerId = 1, Name = "Test Beer"}};

            var messageCoordinator = new MessageCoordinator();
            presenter.Messages = messageCoordinator;

            //Act
            view.Raise(x => x.Load += null, null, null);
            messageCoordinator.Publish(beerList);
            messageCoordinator.Close();
            presenter.ReleaseView();

            //Assert
            Assert.IsNotNull(view.Object.Model.BeerCollection);
            service.Verify(x => x.GetBeers(), Times.Never());
        }

        [Test]
        public void Presenter_Filters_Out_Beers_That_Are_Consumed()
        {
            //Arrange
            var view = new Mock<IViewBeersToDrinkSoon>();
            view.Setup(v => v.Model).Returns(new BeerCollectionModel());

            var service = new Mock<IBeerRepository>();

            var beer1 = new Beer { BeerId = 1, Name = "Bigfoot", IsConsumed = true };
            var beer2 = new Beer { BeerId = 2, Name = "Yeti", IsConsumed = false };
            var beerList = new List<Beer> { beer1, beer2 };

            service.Setup(s => s.GetBeers()).Returns(beerList.AsQueryable());

            var presenter = new BeersToDrinkSoonPresenter(view.Object, service.Object);
            var messageCoordinator = new MessageCoordinator();
            presenter.Messages = messageCoordinator;

            //Act
            view.Raise(x => x.Load += null, null, null);
            presenter.ReleaseView();
            messageCoordinator.Close();

            //Assert
            Assert.DoesNotContain(view.Object.Model.BeerCollection, beer1); 
        }

        [Test]
        public void Presenter_Filters_Collection_Down_To_Three_Beers()
        {
            //Arrange
            var view = new Mock<IViewBeersToDrinkSoon>();
            view.Setup(v => v.Model).Returns(new BeerCollectionModel());

            var service = new Mock<IBeerRepository>();

            var beer1 = new Beer { BeerId = 1, Name = "Bigfoot", IsConsumed = true };
            var beer2 = new Beer { BeerId = 2, Name = "Yeti", IsConsumed = false };
            var beerList = new List<Beer> { beer1, beer2 };

            service.Setup(s => s.GetBeers()).Returns(beerList.AsQueryable());

            var presenter = new BeersToDrinkSoonPresenter(view.Object, service.Object);
            var messageCoordinator = new MessageCoordinator();
            presenter.Messages = messageCoordinator;

            //Act
            view.Raise(x => x.Load += null, null, null);
            presenter.ReleaseView();
            messageCoordinator.Close();

            //Assert
            Assert.DoesNotContain(view.Object.Model.BeerCollection, beer1);
        }
    }
}
