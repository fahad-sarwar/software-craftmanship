using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderManagementKata
{
    public class OrderManagementSpec
    {
        [TestClass]
        public class WhenAnOrderIsPlacedForANewOrganisation
        {
            private OrganisationRepositoryStub _organisationRepository;

            [TestInitialize]
            public void Setup()
            {
                _organisationRepository = new OrganisationRepositoryStub();
            }

            [TestMethod]
            public void A_new_organisation_is_created()
            {
                Assert.IsTrue(_organisationRepository.OrganisationCreatedWasCalled);
            }

            [TestMethod]
            public void A_new_contact_is_created()
            {
            }

            [TestMethod]
            public void A_contact_created_event_is_raised()
            {
            }

            [TestMethod]
            public void An_order_is_created()
            {
            }

            [TestMethod]
            public void A_order_created_event_is_raised()
            {
            }
        }

        [TestClass]
        public class WhenAnOrderIsPlacedForAnExistingReseller
        {
        }

        [TestClass]
        public class WhenAnOrderIsPlacedForAnExistingSmallBusiness
        {
        }
    }

    internal class OrganisationRepositoryStub
    {
        public bool OrganisationCreatedWasCalled;
    }
}
