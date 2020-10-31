﻿using System;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Acme.BookStore.Domain.Films;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Acme.AuthorStore
{
    public class AuthorDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly IRepository<Film, Guid> _filmRepository;
        private readonly IGuidGenerator _guidGenerator;

        public AuthorDataSeederContributor(IRepository<Author, Guid> authorRepository,
            IRepository<Film, Guid> filmRepository,
            IGuidGenerator guidGenerator)
        {
            _authorRepository = authorRepository;
            _guidGenerator = guidGenerator;
            _filmRepository = filmRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _authorRepository.GetCountAsync() == 0)
            {
                var authorId = _guidGenerator.Create();
                await _authorRepository.InsertAsync(
                    new Author(authorId, "Peter Jackson", DateTime.Now.AddYears(-60), "bio1"),
                    autoSave: true
                );
                
                await _filmRepository.InsertAsync(
                    new Film { AuthorId = authorId, Name = "Harry Potter1" },
                    autoSave: true);
                await _filmRepository.InsertAsync(
                    new Film { AuthorId = authorId, Name = "Harry Potter2" },
                    autoSave: true);
                await _filmRepository.InsertAsync(
                    new Film { AuthorId = authorId, Name = "Harry Potter3" },
                    autoSave: true);
            }

        }
    }
}