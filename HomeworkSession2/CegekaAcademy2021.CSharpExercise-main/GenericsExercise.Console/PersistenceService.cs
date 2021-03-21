using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExercise.Console
{
    // This class acts as an intermediar (service) between the main program and the given Persistence class
    public class PersistenceService
    {
        private readonly Persistence persistence;
        public PersistenceService()
        {
            persistence = new Persistence();
            
        }

        public void InsertEntity<TEntity>(TEntity entity) where TEntity : IEntity
        {
            // Insert new entity in the "database": student or university (or any other added class implementing IEntity)
            try
            {
                persistence.InsertAsync(entity);
                System.Console.WriteLine("\tEntry succesfully registered.");
            }
            // There are problems with the given id
            catch (ArgumentException argumentException)
            { 
                // Id cannot be empty 
                if (string.IsNullOrWhiteSpace(entity.Id))
                {
                    throw new ArgumentException("\tEntry not registered. Reason: Id cannot be empty.");
                }
                //Id cannot contain %
                else if (entity.Id.Contains("%"))
                {
                    throw new ArgumentException("\tEntry not registered. Reason: Id cannot contain %.");
                }
                // Id cannot be longer than 10 characters
                else if (entity.Id.Length > 10 )
                {
                    throw new ArgumentException("\tEntry not registered. Reason: Id cannot be longer than 10 characters.");
                }
            }
            // Maximum number of entities of certain type already reached 
            catch (InvalidOperationException exception)
            {
                throw new InvalidOperationException("\tEntry not registered. Reason: Cannot insert more than 3 entities of the same type.");
            }
            
        }

        // IEnumerable<TEntity>         - return type: a "collection" of elements of generic type TEntity
        // ViewAllEntities              - function name
        // ViewAllEntities<TEntity>()   - the function is generic and does not take any arguments
        public IEnumerable<TEntity> ViewAllEntities<TEntity>() where TEntity : IEntity   
        {
            return persistence.GetAllAsync<TEntity>().Result;
        }
    }
}
