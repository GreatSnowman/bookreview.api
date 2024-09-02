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
            var query = PublisherSQLQueries.InsertQuery();
            var param = PublisherSQLQueries.InsertParameters(publisher);

            var result = await _repository.ExecuteQueryStringSingleAsync<PublisherModel>(query, param);

            return result;
        }

        public async Task<PublisherModel> GetPublisher(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PublisherModel> UpdatePublisher(PublisherModel publisher)
        {
            var query = PublisherSQLQueries.UpdateQuery();
            var param = PublisherSQLQueries.UpdateParameters(publisher);
            var result = await _repository.ExecuteQueryStringSingleAsync<PublisherModel>(query, param);

            return result;
        }
    }
}
