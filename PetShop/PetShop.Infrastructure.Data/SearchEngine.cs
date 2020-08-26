using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class SearchEngine : ISearchEngine
    {
        public List<T> Search<T>(List<T> searchList, string searchTitle) where T : ISearchAble
        {
            string[] searchTerms = searchTitle.ToLower().Split('%');
            List<T> matches = new List<T>();

            foreach (T entity in searchList)
            {
                int size = 0;
                if (!searchTitle.StartsWith('%'))
                {
                    if (!entity.searchValue().ToLower().StartsWith(searchTerms[0]))
                    {
                        continue;
                    }
                }
                else
                {
                    size++;
                }

                String entityTitle = entity.searchValue().ToLower();

                for (int i = size; i < searchTerms.Length; i++)
                {

                    if (entityTitle.Contains(searchTerms[i]))
                    {
                        int index = entityTitle.IndexOf(searchTerms[i]);
                        entityTitle = entityTitle.Substring(index + searchTerms[i].Length);
                    }
                    else
                    {
                        break;
                    }

                    if (searchTitle.EndsWith("%"))
                    {
                        if (entityTitle.Length > 0)
                        {
                            matches.Add(entity);
                            break;
                        }
                    }
                    else
                    {
                        if (entityTitle.Length == 0)
                        {
                            matches.Add(entity);
                            break;
                        }
                    }
                }
            }
            return matches;
        }
    }
}
