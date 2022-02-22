using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using TesodevMicroservices.OrderService.Application.ViewModel;
using TesodevMicroservices.OrderService.Domain.Entity;

namespace TesodevMicroservices.OrderService.Test.Mock
{
    public class MockMapper : IMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            if (typeof(TDestination) == typeof(Order))
            {
                var mappedObject = new Order() { Id = Guid.NewGuid(), CustomerId = Guid.NewGuid() };
                TDestination result = (TDestination)Convert.ChangeType(mappedObject, typeof(TDestination));
                return result;
            }

            if (typeof(TDestination) == typeof(OrderViewModel))
            {
                var mappedObject = new OrderViewModel();
                TDestination result = (TDestination)Convert.ChangeType(mappedObject, typeof(TDestination));
                return result;
            }

            if (typeof(TDestination) == typeof(List<ListOrdersViewModel>))
            {
                var mappedObject = new List<ListOrdersViewModel>(){new(), new(), new()};
                TDestination result = (TDestination)Convert.ChangeType(mappedObject, typeof(TDestination));
                return result;

            }

            return default;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            if (typeof(TDestination) == typeof(Order))
            {
                var order = new Order() { Id = Guid.NewGuid(), CustomerId = Guid.NewGuid() };
                TDestination result = (TDestination)Convert.ChangeType(order, typeof(TDestination));
                return result;
            }

            return default;

        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            throw new NotImplementedException();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            throw new NotImplementedException();
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            throw new NotImplementedException();
        }

        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions<object, TDestination>> opts)
        {
            throw new NotImplementedException();
        }

        public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            throw new NotImplementedException();
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            throw new NotImplementedException();
        }

        public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions<object, object>> opts)
        {
            throw new NotImplementedException();
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions<object, object>> opts)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, object parameters = null, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, IDictionary<string, object> parameters, params string[] membersToExpand)
        {
            throw new NotImplementedException();
        }

        public IQueryable ProjectTo(IQueryable source, Type destinationType, IDictionary<string, object> parameters = null,
            params string[] membersToExpand)
        {
            throw new NotImplementedException();
        }

        public IConfigurationProvider ConfigurationProvider { get; }
    }
}