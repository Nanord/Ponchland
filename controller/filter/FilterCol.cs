using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponchland.generalData;
using Ponchland.model;

namespace Ponchland.controller.filter
{
    
    class FilterCol
    {
        public static Dictionary<IFilter, bool> Filters { get; private set; }
        private Dictionary<FieldProduct, FieldType> field;

        public FilterCol(Dictionary<FieldProduct, FieldType> field)
        {
            this.field = field;
            Filters = new Dictionary<IFilter, bool>();
            createFilters();
        }

        private bool CheckStatus(Status status) => (
            status == Status.EQUAL || status == Status.NOT_EQUAL ? true : false);


        private void createFilters()
        {
            foreach (KeyValuePair<FieldProduct, FieldType> tmp in field)
            {
                String tmpValue = tmp.Value.value;
                bool con = tmp.Value.status == Status.CONTAINS || tmp.Value.status == Status.EQUAL || tmp.Value.status == Status.MORE ? true : false;
                IFilter filter = null;
                if (tmp.Key == FieldProduct.NAME)
                {
                    if (CheckStatus(tmp.Value.status))
                    {
                         filter = new nameFilterEqual();
                    }
                    else 
                    {
                         filter = new nameFilterContains();
                    }
                }
                if (tmp.Key == FieldProduct.DESCRIPRION)
                {
                    if (CheckStatus(tmp.Value.status))
                    {
                         filter = new descrFilterEqual();;
                    }
                    else
                    {
                         filter = new descrFilterContains();
                    }
                }
                if (tmp.Key == FieldProduct.COST && tmp.Value.status == Status.MORE)
                {
                     filter = new costFilterMore();
                }
                else if (tmp.Key == FieldProduct.COST && tmp.Value.status == Status.LESS)
                {
                    filter = new costFilterLess();
                }
                filter.Value = tmpValue;
                Filters.Add(filter, con);
            }
        }
    }
}
