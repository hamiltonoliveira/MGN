using Applicationcore.Entities;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace PhoneTest
{
    [TestFixture]
    public class PhoneTest
    {

        private PhoneValidation validator;
        public object BaseVerifiersSetComposer { get; private set; }

        [SetUp]
        public void Setup()
        {
            validator = new PhoneValidation();
        }
        

        //Verificando se o número telefone esta nulo
        //inteiro
        [Test]
        public void VerificarNumeroTelefoneNulo()
        {
             validator.ShouldNotHaveValidationErrorFor(Phone => Phone.numero, 0);
        }
        
    }
}