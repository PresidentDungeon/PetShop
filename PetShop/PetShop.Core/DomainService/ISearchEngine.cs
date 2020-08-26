using PetShop.Core.Entities;
using System.Collections.Generic;

namespace PetShop.Core.DomainService
{
    public interface ISearchEngine

    {
        List<T> Search<T>(List<T> searchList, string searchTitle) where T: ISearchAble;
    }
}
