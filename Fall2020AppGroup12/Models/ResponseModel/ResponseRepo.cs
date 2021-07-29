using Fall2020AppGroup12.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ResponseModel
{
    public class ResponseRepo : IResponseRepo
    {

        private ApplicationDbContext database;

        public ResponseRepo(ApplicationDbContext dbContext) //ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        // Add
        public void AddResponse(Response response)
        {
            database.Response.Add(response);
            database.SaveChanges();
        }

        // Edit
        public void EditResponse(Response response)
        {
            database.Response.Update(response);
            database.SaveChanges();
        }

        // Delete
        public void DeleteResponse(Response response)
        {
            database.Response.Remove(response);
            database.SaveChanges();
        }

        // List All
        public List<Response> ListAllResponses()
        {
            List<Response> responses = database.Response.ToList();
            return responses;
        }

        // Search
        public Response FindResponse(int? responseID)
        {
            Response response = database.Response.Find(responseID);

            return response;
        }
    }
}
