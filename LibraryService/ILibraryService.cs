using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Library
{
    [ServiceContract]
    public interface ILibraryService
    {
        [OperationContract]
        string Hello();

        [OperationContract]
        void Upload(FileTransactionModel file);
    }

    [DataContract]
    public class FileTransactionModel
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string FileData { get; set; }
    }
}
