﻿using FluentValidation;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces.Repositories;
using OnboardingSIGDB1.Domain.Interfaces.Validator;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Cargos
{
    public class CargoValidatorService : AbstractValidator<Cargo>, ICargoValidatorService
    {
        private readonly ICargoRepository _cargoRepository;
        public CargoValidatorService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
            
            #region Descricao
            RuleFor(r => r.Descricao)
                .NotEmpty()
                .WithMessage(Messages.DescricaoObrigatoria);
            
            RuleFor(r => r.Descricao)
                .MaximumLength(250)
                .WithMessage(Messages.DescricaoLimiteMax250Caracteres);
            
            RuleFor(x => x)
                .Must(ValidateDescricaoAlreadyExists)
                .WithMessage(Messages.DescricaoRepetida);
            #endregion Descricao
        }

        private bool ValidateDescricaoAlreadyExists(Cargo entity)
        {
            return !_cargoRepository.GetDescricaoAlreadyExists(entity.Id, entity.Descricao);
        }
    }
}