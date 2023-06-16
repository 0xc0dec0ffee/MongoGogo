﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoGogo.Connection
{
    /// <summary>
    /// Represents a lightweight, user-friendly wrapper for the MongoDB collection object.
    /// </summary>
    /// <remarks>
    /// This interface provides an easy-to-use way to perform operations on MongoDB collections. It supports all the functionality provided by the official MongoDB driver's IMongoCollection interface. If necessary, you can still directly access the underlying IMongoCollection object for more advanced operations.
    /// </remarks>
    /// <typeparam name="TDocument"> The Document type</typeparam>
    public interface IGoCollection<TDocument>
    {
        /// <summary>
        /// Gets the underlying MongoDB collection object provided by the official MongoDB driver.
        /// </summary>
        public IMongoCollection<TDocument> MongoCollection { get; }

        /// <summary>
        /// Finds the documents matching the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The returned documents.</returns>
        public IEnumerable<TDocument> Find(Expression<Func<TDocument, bool>> filter);

        /// <summary>
        /// Finds the documents matching the filter.
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="projection">The projection</param>
        /// <param name="goFindOption">The option</param>
        /// <returns></returns>
        public IEnumerable<TDocument> Find(Expression<Func<TDocument, bool>> filter,
                                           Expression<Func<GoProjectionBuilder<TDocument>, GoProjectionDefinition<TDocument>>> projection = default,
                                           GoFindOption goFindOption = default);

        /// <summary>
        /// Asynchronously finds the documents matching the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The returned documents.</returns>
        public Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> filter);

        /// <summary>
        /// Asynchronously finds the documents matching the filter with a projection.
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="projection">The projection</param>
        /// <param name="goFindOption">The option</param>
        /// <returns>The returned documents.</returns>
        public Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> filter,
                                                      Expression<Func<GoProjectionBuilder<TDocument>, GoProjectionDefinition<TDocument>>> projection = default,
                                                      GoFindOption goFindOption = default);

        /// <summary>
        /// Finds one document matching the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The returned document.</returns>
        public TDocument FindOne(Expression<Func<TDocument, bool>> filter);

        /// <summary>
        /// Finds one document matching the filter with a projection.
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="projection">The projection</param>
        /// <param name="goFindOption">The option</param>
        /// <returns>The returned document.</returns>
        public TDocument FindOne(Expression<Func<TDocument, bool>> filter,
                                 Expression<Func<GoProjectionBuilder<TDocument>, GoProjectionDefinition<TDocument>>> projection = default,
                                 GoFindOption goFindOption = default);

        /// <summary>
        /// Asynchronously finds one document matching the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The returned document.</returns>
        public Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filter);

        /// <summary>
        /// Asynchronously finds one document matching the filter with a projection.
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="projection">The projection</param>
        /// <param name="goFindOption">The option</param>
        /// <returns>The returned document.</returns>
        public Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filter,
                                            Expression<Func<GoProjectionBuilder<TDocument>, GoProjectionDefinition<TDocument>>> projection = default,
                                            GoFindOption goFindOption = default);

        /// <summary>
        /// Inserts a single document into the collection.
        /// </summary>
        /// <param name="document">The document to be inserted.</param>
        public void InsertOne(TDocument document);

        /// <summary>
        /// Asynchronously inserts a single document into the collection.
        /// </summary>
        /// <param name="document">The document to be inserted.</param>
        public Task InsertOneAsync(TDocument document);

        /// <summary>
        /// Inserts multiple documents into the collection.
        /// </summary>
        /// <param name="documents">The documents to be inserted.</param>
        public void InsertMany(IEnumerable<TDocument> documents);

        /// <summary>
        /// Asynchronously inserts multiple documents into the collection.
        /// </summary>
        /// <param name="documents">The documents to be inserted.</param>
        public Task InsertManyAsync(IEnumerable<TDocument> documents);

        /// <summary>
        /// Replaces a single document in the collection.
        /// </summary>
        /// <param name="filter">The filter to select the document.</param>
        /// <param name="document">The document to replace the existing one.</param>
        /// <param name="isUpsert">Whether to create a new document if no match is found.</param>
        /// <returns>Theresult of the replace operation.</returns>
        public GoReplaceResult ReplaceOne(Expression<Func<TDocument, bool>> filter,
                                          TDocument document,
                                          bool isUpsert = false);

        /// <summary>
        /// Asynchronously replaces a single document in the collection.
        /// </summary>
        /// <param name="filter">The filter to select the document.</param>
        /// <param name="document">The document to replace the existing one.</param>
        /// <param name="isUpsert">Whether to create a new document if no match is found.</param>
        /// <returns>The result of the replace operation.</returns>
        public Task<GoReplaceResult> ReplaceOneAsync(Expression<Func<TDocument, bool>> filter,
                                                     TDocument document,
                                                     bool isUpsert = false);

        /// <summary>
        /// Counts the number of documents matching the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The count of the documents.</returns>
        public long Count(Expression<Func<TDocument, bool>> filter);

        /// <summary>
        /// Asynchronously counts the number of documents matching the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The count of the documents.</returns>
        public Task<long> CountAsync(Expression<Func<TDocument, bool>> filter);

        /// <summary>
        /// Updates a single document matching the filter.
        /// </summary>
        /// <param name="filter">The filter to select the document.</param>
        /// <param name="set">The update operation to apply.</param>
        /// <param name="isUpsert">Whether to create a new document if no match is found.</param>
        /// <returns>The result of the update operation.</returns>
        public GoUpdateResult UpdateOne(Expression<Func<TDocument, bool>> filter,
                                        Expression<Func<GoUpdateBuilder<TDocument>, GoUpdateDefinition<TDocument>>> set,
                                        bool isUpsert = false);

        /// <summary>
        /// Asynchronously updates a single document matching the filter.
        /// </summary>
        /// <param name="filter">The filter to select the document.</param>
        /// <param name="set">The update operation to apply.</param>
        /// <param name="isUpsert">Whether to create a new document if no match is found.</param>
        /// <returns>The result of the update operation.</returns>
        public Task<GoUpdateResult> UpdateOneAsync(Expression<Func<TDocument, bool>> filter,
                                                   Expression<Func<GoUpdateBuilder<TDocument>, GoUpdateDefinition<TDocument>>> set,
                                                   bool isUpsert = false);

        /// <summary>
        /// Updates multiple documents matching the filter.
        /// </summary>
        /// <param name="filter">The filter to select the documents.</param>
        /// <param name="set">The update operation to apply.</param>
        /// <returns>The result of the update operation.</returns>
        public GoUpdateResult UpdateMany(Expression<Func<TDocument, bool>> filter,
                                         Expression<Func<GoUpdateBuilder<TDocument>, GoUpdateDefinition<TDocument>>> set);

        /// <summary>
        /// Asynchronously updates multiple documents matching the filter.
        /// </summary>
        /// <param name="filter">The filter to select the documents.</param>
        /// <param name="set">The update operation to apply.</param>
        /// <returns>The result of the update operation.</returns>
        public Task<GoUpdateResult> UpdateManyAsync(Expression<Func<TDocument, bool>> filter,
                                                    Expression<Func<GoUpdateBuilder<TDocument>, GoUpdateDefinition<TDocument>>> set);

        /// <summary>
        /// Deletes a single document matching the filter.
        /// </summary>
        /// <param name="filter">The filter to select the document.</param>
        /// <returns>The result of the delete operation.</returns>
        public GoDeleteResult DeleteOne(Expression<Func<TDocument, bool>> filter);

        /// <summary>
        /// Asynchronously deletes a single document matching the filter.
        /// </summary>
        /// <param name="filter">The filter to select the document.</param>
        /// <returns>The result of the delete operation.</returns>
        public Task<GoDeleteResult> DeleteOneAsync(Expression<Func<TDocument, bool>> filter);

        /// <summary>
        /// Deletes multiple documents matching the filter.
        /// </summary>
        /// <param name="filter">The filter to select the documents.</param>
        /// <returns>The result of the delete operation.</returns>
        public GoDeleteResult DeleteMany(Expression<Func<TDocument, bool>> filter);

        /// <summary>
        /// Asynchronously deletes multiple documents matching the filter.
        /// </summary>
        /// <param name="filter">The filter to select the documents.</param>
        /// <returns>The result of the delete operation.</returns>
        public Task<GoDeleteResult> DeleteManyAsync(Expression<Func<TDocument, bool>> filter);

        /// <summary>
        /// Create new IGoBulker instance of this collection.
        /// </summary>
        public IGoBulker<TDocument> NewBulker();
    }
}
