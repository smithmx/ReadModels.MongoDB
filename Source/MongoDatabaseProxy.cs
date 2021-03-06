/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/
using System.Threading;
using System.Threading.Tasks;
using Dolittle.ResourceTypes.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dolittle.ReadModels.MongoDB
{
    /// <summary>
    /// Represents a proxy for <see cref="IMongoDatabase"/>
    /// </summary>
    /// <remarks>
    /// The proxy allows us to be living in the right scope and still be able to take dependencies to
    /// the IMongoDatabase directly. This means it can be safe to assume that you're getting the 
    /// database for the correct tenant, unless being held onto in something that has a longer lifecycle
    /// than per tenant.
    /// </remarks>
    public class MongoDatabaseProxy : IMongoDatabase
    {
        readonly Configuration _configuration;

        /// <summary>
        /// Initializes a new instance of <see cref="MongoDatabaseProxy"/>
        /// </summary>
        /// <param name="configuration"><see cref="Configuration"/> to use</param>
        public MongoDatabaseProxy(IConfigurationFor<Configuration> configuration)
        {
            _configuration = configuration.Instance;
        }

        /// <inheritdoc/>
        public IMongoClient Client => _configuration.Database.Client;

        /// <inheritdoc/>
        public DatabaseNamespace DatabaseNamespace => _configuration.Database.DatabaseNamespace;

        /// <inheritdoc/>
        public MongoDatabaseSettings Settings => _configuration.Database.Settings;

        /// <inheritdoc/>
        public void CreateCollection(string name, CreateCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            _configuration.Database.CreateCollection(name, options, cancellationToken);
        }

        /// <inheritdoc/>
        public void CreateCollection(IClientSessionHandle session, string name, CreateCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            _configuration.Database.CreateCollection(session,name, options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task CreateCollectionAsync(string name, CreateCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.CreateCollectionAsync(name, options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task CreateCollectionAsync(IClientSessionHandle session, string name, CreateCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.CreateCollectionAsync(session, name, options, cancellationToken);
        }

        /// <inheritdoc/>
        public void CreateView<TDocument, TResult>(string viewName, string viewOn, PipelineDefinition<TDocument, TResult> pipeline, CreateViewOptions<TDocument> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            _configuration.Database.CreateView<TDocument, TResult>(viewName, viewOn, pipeline, options, cancellationToken);
        }

        /// <inheritdoc/>
        public void CreateView<TDocument, TResult>(IClientSessionHandle session, string viewName, string viewOn, PipelineDefinition<TDocument, TResult> pipeline, CreateViewOptions<TDocument> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            _configuration.Database.CreateView<TDocument, TResult>(session, viewName, viewOn, pipeline, options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task CreateViewAsync<TDocument, TResult>(string viewName, string viewOn, PipelineDefinition<TDocument, TResult> pipeline, CreateViewOptions<TDocument> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.CreateViewAsync<TDocument, TResult>(viewName, viewOn, pipeline, options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task CreateViewAsync<TDocument, TResult>(IClientSessionHandle session, string viewName, string viewOn, PipelineDefinition<TDocument, TResult> pipeline, CreateViewOptions<TDocument> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.CreateViewAsync<TDocument, TResult>(session,viewName, viewOn, pipeline, options, cancellationToken);
        }

        /// <inheritdoc/>
        public void DropCollection(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            _configuration.Database.DropCollection(name, cancellationToken);
        }

        /// <inheritdoc/>
        public void DropCollection(IClientSessionHandle session, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            _configuration.Database.DropCollection(session, name, cancellationToken);
        }

        /// <inheritdoc/>
        public Task DropCollectionAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.DropCollectionAsync(name, cancellationToken);
        }

        /// <inheritdoc/>
        public Task DropCollectionAsync(IClientSessionHandle session, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.DropCollectionAsync(session, name, cancellationToken);
        }

        /// <inheritdoc/>
        public IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings settings = null)
        {
            return _configuration.Database.GetCollection<TDocument>(name, settings);
        }

        /// <inheritdoc/>
        public IAsyncCursor<string> ListCollectionNames(ListCollectionNamesOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.ListCollectionNames(options, cancellationToken);
        }

        /// <inheritdoc/>
        public IAsyncCursor<string> ListCollectionNames(IClientSessionHandle session, ListCollectionNamesOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.ListCollectionNames(session, options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IAsyncCursor<string>> ListCollectionNamesAsync(ListCollectionNamesOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.ListCollectionNamesAsync(options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IAsyncCursor<string>> ListCollectionNamesAsync(IClientSessionHandle session, ListCollectionNamesOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.ListCollectionNamesAsync(session, options, cancellationToken);
        }

        /// <inheritdoc/>
        public IAsyncCursor<BsonDocument> ListCollections(ListCollectionsOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.ListCollections(options, cancellationToken);
        }

        /// <inheritdoc/>
        public IAsyncCursor<BsonDocument> ListCollections(IClientSessionHandle session, ListCollectionsOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.ListCollections(session, options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IAsyncCursor<BsonDocument>> ListCollectionsAsync(ListCollectionsOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.ListCollectionsAsync(options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IAsyncCursor<BsonDocument>> ListCollectionsAsync(IClientSessionHandle session, ListCollectionsOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.ListCollectionsAsync(session, options, cancellationToken);
        }

        /// <inheritdoc/>
        public void RenameCollection(string oldName, string newName, RenameCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            _configuration.Database.RenameCollection(oldName, newName, options, cancellationToken);
        }

        /// <inheritdoc/>
        public void RenameCollection(IClientSessionHandle session, string oldName, string newName, RenameCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            _configuration.Database.RenameCollection(session, oldName, newName, options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task RenameCollectionAsync(string oldName, string newName, RenameCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.RenameCollectionAsync(oldName, newName, options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task RenameCollectionAsync(IClientSessionHandle session, string oldName, string newName, RenameCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.RenameCollectionAsync(session, oldName, newName, options, cancellationToken);
        }

        /// <inheritdoc/>
        public TResult RunCommand<TResult>(Command<TResult> command, ReadPreference readPreference = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.RunCommand<TResult>(command, readPreference, cancellationToken);
        }

        /// <inheritdoc/>
        public TResult RunCommand<TResult>(IClientSessionHandle session, Command<TResult> command, ReadPreference readPreference = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.RunCommand(session, command, readPreference, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<TResult> RunCommandAsync<TResult>(Command<TResult> command, ReadPreference readPreference = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.RunCommandAsync(command, readPreference, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<TResult> RunCommandAsync<TResult>(IClientSessionHandle session, Command<TResult> command, ReadPreference readPreference = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.RunCommandAsync(session, command, readPreference, cancellationToken);
        }

        /// <inheritdoc/>
        public IAsyncCursor<TResult> Watch<TResult>(PipelineDefinition<ChangeStreamDocument<BsonDocument>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.Watch(pipeline, options, cancellationToken);
        }

        /// <inheritdoc/>
        public IAsyncCursor<TResult> Watch<TResult>(IClientSessionHandle session, PipelineDefinition<ChangeStreamDocument<BsonDocument>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.Watch(session, pipeline, options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IAsyncCursor<TResult>> WatchAsync<TResult>(PipelineDefinition<ChangeStreamDocument<BsonDocument>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.WatchAsync(pipeline, options, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IAsyncCursor<TResult>> WatchAsync<TResult>(IClientSessionHandle session, PipelineDefinition<ChangeStreamDocument<BsonDocument>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.Database.WatchAsync(session, pipeline, options, cancellationToken);
        }

        /// <inheritdoc/>
        public IMongoDatabase WithReadConcern(ReadConcern readConcern)
        {
            return _configuration.Database.WithReadConcern(readConcern);
        }

        /// <inheritdoc/>
        public IMongoDatabase WithReadPreference(ReadPreference readPreference)
        {
            return _configuration.Database.WithReadPreference(readPreference);
        }

        /// <inheritdoc/>
        public IMongoDatabase WithWriteConcern(WriteConcern writeConcern)
        {
            return _configuration.Database.WithWriteConcern(writeConcern);
        }
    }
}