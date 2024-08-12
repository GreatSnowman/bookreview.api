using atomic.chicken.common.Models;
using atomic.chicken.infrastructure.Repository;
using atomic.chicken.infrastructure.SQL;
using atomic.chicken.service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atomic.chicken.service.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IDapperRepository _repository;

        public PublisherService(IDapperRepository repository)
        {
            _repository = repository;
        }

        public async Task<PublisherModel> AddNewPublisher(PublisherModel publisher)
        {
            var query = SQLQueries.PublisherInsert();
            var param = SQLQueries.PublisherInsertParameters(publisher);

            var result = await _repository.ExecuteQueryStringSingleAsync<PublisherModel>(query, param);

            return result;
        }

        public Task<PublisherModel> GetPublisher(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PublisherModel> UpdatePublisher(PublisherModel author)
        {
            throw new NotImplementedException();
        }
    }
}
