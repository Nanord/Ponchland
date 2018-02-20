using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponchland.generalData;
using Ponchland.model;

namespace Ponchland.controller.filter
{
    class FilterContr
    {
        private List<Product> product;

        private void SetProduct(List<Category> category)
        {
            product = new List<Product>();
            foreach (Category tmp in category)
            {
                foreach (Product tmpProduct in tmp.Product)
                {
                    product.Add(tmpProduct);
                }
            }
        }

        public FilterContr(List<Category> category, Dictionary<FieldProduct, FieldType> field)
        {
            SetProduct(category);
            FilterCol filterCol = new FilterCol(field);
        }

        public List<Product> GetFilterProduct()
        {
            
            List<Product> FilterProduct = new List<Product>();
            List<Product> delPoduct = new List<Product>();
            
            bool filterValue = true;
            int i = 0, j = 0;
            foreach (Product tmp in product)
            {
                bool eq = true;
                foreach (KeyValuePair<IFilter, bool> filter in FilterCol.Filters)
                {

                    if (filter.Key.Check(tmp) && filter.Value)
                    {
                        FilterProduct.Add(tmp);
                        i++;
                    }
                    //j = i;
                    if (!filter.Value && !filter.Key.Check(tmp) && eq)
                    {
                        filterValue = false;
                        eq = false;
                        delPoduct.Add(tmp);        
                    }
                }
            }
            if(!filterValue)
            {
                List<Product> t = new List<Product>();
                foreach (Product tmp in product)
                {
                    if(FilterProduct.Count > 0)
                    {
                        foreach (Product tmpFilterProduct in FilterProduct)
                        {
                            if (tmp != tmpFilterProduct)
                            {
                                foreach (Product tmpDelProduct in delPoduct)
                                {
                                    if (tmp != tmpDelProduct)
                                    {
                                        t.Add(tmp);
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        foreach (Product tmpDelProduct in delPoduct)
                        {
                            if (tmp != tmpDelProduct)
                            {
                                t.Add(tmp);
                            }
                        }
                    }
                    
                }
                foreach(Product tmp in t)
                {
                    FilterProduct.Add(tmp);
                }
            }
            return FilterProduct;
        }
    }
}
