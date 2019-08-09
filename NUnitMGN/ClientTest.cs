using Applicationcore.Entities;
using FluentValidation.TestHelper;
using NUnit.Framework;
using System;

namespace ClientTest
{
    [TestFixture]
    public class ClientTest
    {

        private ClientValidation validator;
        public object BaseVerifiersSetComposer { get; private set; }

        [SetUp]
        public void Setup()
        {
            validator = new ClientValidation();
        }


        //Verificando se o Nome não é nulo e que tenha > 3 caracteres.
        //String
        [Test]
        public void VerificarNomeDoClienteNaoVazio()
        {
             validator.ShouldNotHaveValidationErrorFor(Client => Client.name, "K2L");
        }

        //Verificando se o documento não é nulo.
        //inteiro
        [Test]
        public void VerificarNumeroDocumentoNaoNulo()
        {
            validator.ShouldNotHaveValidationErrorFor(Client => Client.identificationDocument, 123456);
        }

        //Verificando se foi digitado a data do aniversário.
        //date  new DateTime(2017, 1, 18)  não pode ser nulo.
        [Test]
        public void VerificarSeFoiDigitadoAniversario()
        {
          validator.ShouldNotHaveValidationErrorFor(Client => Client.birdDate, new DateTime(1980, 1, 18));
        }


        //Verificando se foi digitado a data do aniversário.
        //date
        [Test]
        public void VerificarSeDigitadoGenero()
        {
            validator.ShouldNotHaveValidationErrorFor(Client => Client.gender, "MASCULINO");
        }
    }
}