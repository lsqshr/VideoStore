using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Business.Components.Interfaces;
using VideoStore.Business.Entities;
using System.Transactions;

namespace VideoStore.Business.Components
{
    public class OrderProvider : IOrderProvider
    {
        public void SubmitOrder(Entities.Order pOrder)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Orders.ApplyChanges(pOrder);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }


    }
}
