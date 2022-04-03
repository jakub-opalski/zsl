using System;
using System.Collections.Generic;
using VehicleFactory.Enums;

namespace VehicleFactory.Helpers
{
    public class ProductionStatusHelper
    {
        public static Dictionary<ProductionStatus, ProductionStatus?> AllowedProductionStatusFlow
            = new Dictionary<ProductionStatus, ProductionStatus?>
            {
                { ProductionStatus.Unknown, ProductionStatus.ScheduledForProduction },
                { ProductionStatus.ScheduledForProduction, ProductionStatus.InProduction },
                { ProductionStatus.InProduction, ProductionStatus.Produced },
                { ProductionStatus.Produced, ProductionStatus.Shipped },
                { ProductionStatus.Shipped, null }
            };

        public static ProductionStatus MoveNext(ProductionStatus currentProductionStatus)
        {
            ProductionStatus? nextValue = null;
            if (AllowedProductionStatusFlow.ContainsKey(currentProductionStatus))
            {
                nextValue = AllowedProductionStatusFlow[currentProductionStatus].Value;
                if (nextValue == null)
                {
                    throw new ArgumentException("There is no flow for given production status.");
                }
                return nextValue.Value;
            }
            else
            {
                throw new ArgumentException("There is no flow for given production status.");
            }
        }
    }
}
