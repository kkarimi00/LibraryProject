using Library.Application.Books.Validations;
using Library.Data.Repositories;
using Library.Domain.Entities;
using Library.Domain.RepositoryContracts;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Library.IoC
{
    public class DependencyContainer
    {

        public static void RegisterServices(IServiceCollection services)
        {
            //Infra.Data Layer
            services.AddScoped<IBookRepository, BookRepository>();

            //Domain layer
            services.AddSingleton<IValidator<Book>, BookValidation>();

        }
    }
}
