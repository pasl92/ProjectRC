using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectRC;
using System;

namespace RcShopTest
{
    [TestClass]
    public class CreateObjectsTests
    {
        [TestMethod]
        public void CreateDostawcaObject()
        {
            dostawa newDostawca = new dostawa();

            newDostawca.cena = 2;
            newDostawca.id_dostawa = 1;
            newDostawca.nazwa = "Test";

            Assert.AreEqual(newDostawca.cena, 2);
            Assert.AreEqual(newDostawca.id_dostawa, 1);
            Assert.AreEqual(newDostawca.nazwa, "Test");
        }

        [TestMethod]
        public void CreateKlienciObject()
        {
            klienci newKlient = new klienci();

            newKlient.id_klienci = 2;
            newKlient.imie = "Test";
            newKlient.nazwisko = "Test";
            newKlient.nr_tel = 123456789;

            Assert.AreEqual(newKlient.id_klienci, 2);
            Assert.AreEqual(newKlient.imie, "Test");
            Assert.AreEqual(newKlient.nazwisko, "Test");
            Assert.AreEqual(newKlient.nr_tel, 123456789);

        }

        [TestMethod]
        public void CreateProduktyObject()
        {
            produkty newProdukt = new produkty();

            newProdukt.id_produktu = 2;
            newProdukt.nazwa = "Test";
            newProdukt.cena = 100;
            newProdukt.koszt_zakup = 100;

            Assert.AreEqual(newProdukt.id_produktu, 2);
            Assert.AreEqual(newProdukt.nazwa, "Test");
            Assert.AreEqual(newProdukt.cena, 100);
            Assert.AreEqual(newProdukt.koszt_zakup, 100);

        }

        [TestMethod]
        public void CreateZamowieniaObject()
        {
            zamowienia newZamowienie = new zamowienia();
            DateTime date1 = new DateTime(2015, 12, 25);

            newZamowienie.id_zamowienia = 2;
            newZamowienie.rabat = 0;
            newZamowienie.id_klienta = 1;
            newZamowienie.id_produktu = 1;
            newZamowienie.data_zakupu = date1;
            //newZamowienie.klienci.id_klienci = 1;
            //newZamowienie.klienci.imie = "Test";
            //newZamowienie.klienci.nazwisko = "Test";
            //newZamowienie.klienci.nr_tel = 123456789;


            Assert.AreEqual(newZamowienie.id_zamowienia, 2);
            Assert.AreEqual(newZamowienie.rabat, 0);
            Assert.AreEqual(newZamowienie.id_klienta, 1);
            Assert.AreEqual(newZamowienie.id_produktu, 1);
            Assert.AreEqual(newZamowienie.data_zakupu, date1);

            //Assert.AreEqual(newZamowienie.klienci.id_klienci, 1);
            //Assert.AreEqual(newZamowienie.klienci.id_klienci, "Test");
            //Assert.AreEqual(newZamowienie.klienci.id_klienci, "Test");
            //Assert.AreEqual(newZamowienie.klienci.id_klienci, 123456789);
        }
    }
}
