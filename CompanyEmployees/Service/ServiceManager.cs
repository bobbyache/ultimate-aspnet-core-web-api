﻿using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager: IServiceManager
    {
        private readonly Lazy<ICompanyService> companyService;
        private readonly Lazy<IEmployeeService> employeeService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger));
            employeeService = new Lazy<IEmployeeService>(() =>  new EmployeeService(repositoryManager, logger));
        }

        public ICompanyService CompanyService => companyService.Value;
        public IEmployeeService EmployeeService => employeeService.Value;
    }
}
