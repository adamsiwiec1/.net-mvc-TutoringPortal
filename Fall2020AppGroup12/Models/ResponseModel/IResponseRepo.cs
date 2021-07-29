using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ResponseModel
{
    public interface IResponseRepo
    {

        List<Response> ListAllResponses();

        void AddResponse(Response response);
        void DeleteResponse(Response response);
        void EditResponse(Response response);
        Response FindResponse(int? responseID);
    }
}
