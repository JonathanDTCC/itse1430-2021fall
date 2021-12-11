/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            // Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            // Validate product
            ObjectValidator.Validate(product);

            var existing = FindByName(product.Name);
            if (existing != null)
                throw new Exception("Product must be unique");

            //Emulate database by storing copy
            return AddCore(product);
        }

        private Product FindByName ( string name ) => GetAllCore().FirstOrDefault(product => String.Compare(name, product.Name, true) == 0);

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            // Check arguments
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than or equal to 0");

            return GetCore(id);
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            // Check arguments
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than or equal to 0");

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            // Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            // Validate product
            ObjectValidator.Validate(product);

            //Get existing product
            var existing = GetCore(product.Id);
            if (existing == null)
                throw new Exception("Product not found");

            var dup = FindByName(product.Name); //product.Name
            if (dup != null && dup.Id != product.Id)
                throw new InvalidOperationException("Product must be unique");

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );
        #endregion
    }
}
