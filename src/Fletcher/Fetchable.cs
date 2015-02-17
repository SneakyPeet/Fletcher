using System;
using System.Linq.Expressions;
using System.Text;
using Fletcher.Exceptions;

namespace Fletcher
{
    public abstract class Fetchable<T, TResult> : Fetchable where T : Fetchable<T, TResult>
    {
        protected Fetchable(string container) : base(container) { }

        public Fetchable<T, TResult>  Where(Expression<Func<TResult, bool>> expression)
        {
            SetWhere(expression);
            return this;
        }
    }

    public abstract class Fetchable
    {
        public string Container { get; private set; }

        protected Fetchable(string container)
        {
            this.Container = container;
            this.Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(this.Container))
            {
                throw new FetchableContainerEmptyException();
            }
        }

        public LambdaExpression WhereClause { get; private set; }

        /// <summary>
        /// Rather Use .Where()
        /// </summary>
        protected void SetWhere(LambdaExpression where)
        {
            this.WhereClause = where;
        }

        public bool HasWhereClause
        {
            get
            {
                return this.WhereClause != null;
            }
        }
    }
}
