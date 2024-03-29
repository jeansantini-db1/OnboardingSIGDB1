﻿using Bogus;
using OnboardingSIGDB1.Domain.Dto.Empresas;
using OnboardingSIGDB1.Domain.Entities;

namespace OnboardingSIGDB1.Test.Builder;

public class EmpresaBuilder
{
    private int _id;
    private string _nome;
    private string _cnpj;
    private DateTime? _dataFundacao;

    public EmpresaBuilder()
    {
        var faker = new Faker();
        _nome = faker.Random.String2(1, 150);
        _cnpj = GerarCnpj();
        _dataFundacao = faker.Date.Past(30);
        
    }

    public static EmpresaBuilder Novo()
    {
        return new EmpresaBuilder();
    }

    public EmpresaBuilder ComNome(string nome)
    {
        _nome = nome;
        return this;
    }
    
    public EmpresaBuilder ComCnpj(string cnpj)
    {
        _cnpj = cnpj;
        return this;
    }    
    
    public EmpresaBuilder ComDataFundacao(DateTime? dataFundacao)
    {
        _dataFundacao = dataFundacao;
        return this;
    }  
    
    public EmpresaBuilder ComId(int id)
    {
        _id = id;
        return this;
    }

    public Empresa Build()
    {
        var empresa = new Empresa();
        empresa.Id = _id;
        empresa.SetNome(_nome);
        empresa.SetCnPj(_cnpj);
        empresa.SetDataFundacao(_dataFundacao);
        return empresa;
    } 
    
    public EmpresaDto BuildDto()
    {
        var empresa = new EmpresaDto();
        empresa.Id = _id;
        empresa.Nome = _nome;
        empresa.Cnpj = _cnpj;
        empresa.DataFundacao = _dataFundacao?.ToString("dd/MM/yyyy");
        return empresa;
    }
    
    public static String GerarCnpj()
    {
        int soma = 0, resto = 0;
        var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        var rnd = new Random();
        var semente = rnd.Next(10000000, 99999999).ToString() + "0001";

        for (var i = 0; i < 12; i++)
            soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        semente += resto;
        soma = 0;

        for (var i = 0; i < 13; i++)
            soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

        resto = soma % 11;

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        semente += resto;
        return semente;
    }
}