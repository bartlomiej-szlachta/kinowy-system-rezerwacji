﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinowySystemRezerwacji.dto;
using KinowySystemRezerwacji.service.dao;
using KinowySystemRezerwacji.service.model;

namespace KinowySystemRezerwacji.service
{
    /// <summary>
    /// Logika biznesowa aplikacji.
    /// </summary>
    internal class Service
    {
        #region Private fields

        /// <summary>
        /// Obiekt zalogowanego użytkownika.
        /// </summary>
        private UzytkownikEntity loggedUser = null;

        #endregion

        #region Shared with Presenter

        /// <summary>
        /// Event potwierdzający ukończenie logowania się do systemu.
        /// </summary>
        internal event Action<string> LoggingInCompleted;

        /// <summary>
        /// Event reprezentujący prostą odpowiedź informującą o suckesie danej operacji.
        /// </summary>
        internal event Action<bool, string> BasicResponse;

        /// <summary>
        /// Metoda rejestrująca w bazie dnaych nowego użytkownika.
        /// </summary>
        /// <param name="request">Dane dotyczące nowego użytkownika</param>
        internal void Register(RegisterRequest request)
        {
            UzytkownikRepository uzytkownikRepository = new UzytkownikRepository();
            if (uzytkownikRepository.ExistsByNazwaUzytkownika(request.Username))
            {
                BasicResponse?.Invoke(false, "Użytkownik o takiej nazwie już istnieje");
            }
            else
            {
                UzytkownikEntity userToRegister = new UzytkownikEntity(request.Username, request.Password, request.FirstName, request.LastName, request.Email, request.Birthday);
                uzytkownikRepository.Save(userToRegister);
                BasicResponse?.Invoke(true, "Pomyślnie zarejestrowano użytkownika");
            }
        }

        /// <summary>
        /// Metoda logująca użytkownika.
        /// </summary>
        /// <param name="username">Nazwa użytkownika</param>
        /// <param name="password">Hasło użytkownika</param>
        internal void LogIn(string username, string password)
        {
            string NOT_LOGGED_IN = "Nie udało się zalogować";
            UzytkownikRepository uzytkownikRepository = new UzytkownikRepository();
            UzytkownikEntity uzytkownik = uzytkownikRepository.FindByNazwaUzytkownika(username).OrElseThrow(NOT_LOGGED_IN);
            if (Security.HashPassword(password) == uzytkownik.Haslo)
            {
                loggedUser = uzytkownik;
                LoggingInCompleted?.Invoke("Pomyślnie zalogowano do systemu");
            }
            else
            {
                throw new Exception(NOT_LOGGED_IN);
            }
        }

        /// <summary>
        /// Metoda wylogowywująca użytkownika.
        /// </summary>
        internal void LogOut()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metoda zwracająca listę wcześniejszych rezerwacji.
        /// </summary>
        /// <returns>Informacje o wcześniejszych rezerwacjach</returns>
        internal BookingResponse[] GetBookings()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metoda zwracająca listę dostępnych seansów.
        /// </summary>
        /// <param name="date">Data, dla której mają zostać wyświetlone seanse</param>
        /// <returns>Informacje o dostępnych seansach</returns>
        internal ShowingResponse[] GetShowings(DateTime date)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metoda zwracająca listę miejsc na dany seans.
        /// </summary>
        /// <param name="showingId">ID wybranego seansu</param>
        /// <returns>Informacje o miejscach na sali</returns>
        internal SeatToChooseResponse[] GetSeats(int showingId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metoda tworząca rezerwację dla zalogowanego użytkownika.
        /// </summary>
        /// <param name="request">Dane dotyczące wybranego seansu i miejsc</param>
        internal void BookSeats(BookSeatsRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
