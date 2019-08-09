using Applicationcore.Entities;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace AdressTest
{
    [TestFixture]
    public class AdressTest
    {

        private AdressValidation validator;
        public object BaseVerifiersSetComposer { get; private set; }

        [SetUp]
        public void Setup()
        {
            validator = new AdressValidation();
        }


        //Verificando se o endere�o n�o � nulo e que tenha >3 caracteres.
        [Test]
        public void VerificarEndereNaoEstaNuloAcimaDe3Caracteres()
        {
             validator.ShouldNotHaveValidationErrorFor(Adress => Adress.street, "K2L");
        }

        //Verificando se o n�mero da rua tem informa��o.
        //Campo Num�rico
        [Test]
        public void VerificarSeNumeroDaRuaTemdado()
        {
            validator.ShouldNotHaveValidationErrorFor(Adress => Adress.number,202);
        }

        //Verificando tem informa��o da vizinhan�a.
        //Campo String 
        [Test]
        public void VerificarSeVizinhancaTemDado()
        {
            validator.ShouldNotHaveValidationErrorFor(Adress => Adress.neightborhood, "aaw");
        }

        //Verificando tem informa��o Cidade.
        //Campo String
        [Test]
        public void VerificarSeCidadeTemDado()
        {
            validator.ShouldNotHaveValidationErrorFor(Adress => Adress.city, "aaa");
        }


        //Verificando tem informa��o estado.
        //Campo String
        [Test]
        public void VerificarSeEstadoNaoNulaSeTem2caracteresTemDado()
        {
            validator.ShouldNotHaveValidationErrorFor(Adress => Adress.state, "RJ");
        }







    }
}