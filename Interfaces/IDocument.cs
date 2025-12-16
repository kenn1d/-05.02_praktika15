

using System.Collections.Generic;
using System.Windows.Documents;

namespace praktika15.Interfaces
{
    public interface IDocument
    {
        void Save(bool Update = false);
        List<Models.Document> AllDocuments();
        void Delete();
    }
}
