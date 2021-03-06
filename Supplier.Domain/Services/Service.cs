﻿using FluentValidation;
using SupplierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierProject.Domain.Services
{
    public abstract class Service
    {
        protected bool Validate<TValidation, TEntity>(TValidation validation, TEntity entity)
            where TValidation : AbstractValidator<TEntity> where TEntity : Entity
        {
            var validate = validation.Validate(entity);

            if (validate.IsValid) return true;

            return false;
        }
    }
}
