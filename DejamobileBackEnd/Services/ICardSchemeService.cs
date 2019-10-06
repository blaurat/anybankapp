using DejamobileBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DejamobileBackEnd.Services
{
    public interface ICardSchemeService
    {
        List<CardScheme> GetAll();
    }
}
