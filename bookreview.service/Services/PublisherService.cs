using bookreview.common.Models;
using bookreview.infrastructure.Repository;
using bookreview.infrastructure.SQL;
using bookreview.infrastructure.SQL.Author;
using bookreview.service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookreview.service.Services
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

        public async Task<PublisherModel> PatchProperty(PatchModel model)
        {
            try
            {
                var paramaters = PublisherSQLQueries.PatchParameter(model);
                var query = PublisherSQLQueries.PatchQuery(model.PropertyName);
                var result = await _repository.ExecuteQueryStringSingleAsync<PublisherModel>(query, paramaters);

                return result;
            }
            catch (Exception ex)
            {
                var publisher = new PublisherModel();
                publisher.Error.Message = ex.Message;

                return publisher;
            }
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
