using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ESW19Backup2.Data;
using ESW19Backup2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ESW19Backup2.Controllers
{
    public class EstatisticaController : Controller
    {
        private DateTime meses;
        private Funcionario fun;

        private readonly ApplicationDbContext _context;


        public EstatisticaController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Home
        public ActionResult Index()
        {

            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Janeiro", countJan()));
            dataPoints.Add(new DataPoint("Fevereiro", countFev()));
            dataPoints.Add(new DataPoint("Março", countMar()));
            dataPoints.Add(new DataPoint("Abril", countAbri()));
            dataPoints.Add(new DataPoint("Maio", countMaio()));
            dataPoints.Add(new DataPoint("Junho", countJun()));
            dataPoints.Add(new DataPoint("Julho", countJul()));
            dataPoints.Add(new DataPoint("Agosto", countAgo()));
            dataPoints.Add(new DataPoint("Setembro", countSet()));
            dataPoints.Add(new DataPoint("Outubro", countOut()));
            dataPoints.Add(new DataPoint("Novembro", countNov()));
            dataPoints.Add(new DataPoint("Dezembro", countDez()));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        // GET: Home
        public ActionResult Index2()
        {

            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Janeiro", countJanCaesAdoptados()));
            dataPoints.Add(new DataPoint("Fevereiro", countFevCaesAdoptados()));
            dataPoints.Add(new DataPoint("Março", countMarCaesAdoptados()));
            dataPoints.Add(new DataPoint("Abril", countAbrilCaesAdoptados()));
            dataPoints.Add(new DataPoint("Maio", countMaioCaesAdoptados()));
            dataPoints.Add(new DataPoint("Junho", countJunCaesAdoptados()));
            dataPoints.Add(new DataPoint("Julho", countJulCaesAdoptados()));
            dataPoints.Add(new DataPoint("Agosto", countAgoCaesAdoptados()));
            dataPoints.Add(new DataPoint("Setembro", countSetCaesAdoptados()));
            dataPoints.Add(new DataPoint("Outubro", countOutCaesAdoptados()));
            dataPoints.Add(new DataPoint("Novembro", countNovCaesAdoptados()));
            dataPoints.Add(new DataPoint("Dezembro", countDezCaesAdoptados()));


            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

         public ActionResult Index3()
        {

            List<DataPoint> dataPoints = new List<DataPoint>();
            
            dataPoints.Add(new DataPoint("Jan", countJanCao()));
            dataPoints.Add(new DataPoint("Feb", countFevCao()));
            dataPoints.Add(new DataPoint("Mar", countMarCao()));
            dataPoints.Add(new DataPoint("Apr", countAbriCao()));
            dataPoints.Add(new DataPoint("May", countMaioCao()));
            dataPoints.Add(new DataPoint("Jun", countJunCao()));
            dataPoints.Add(new DataPoint("July", countJulCao()));
            dataPoints.Add(new DataPoint("Aug", countAgoCao()));
            dataPoints.Add(new DataPoint("Sep", countSetCao()));
            dataPoints.Add(new DataPoint("Oct", countOutCao()));
            dataPoints.Add(new DataPoint("Nov", countNovCao()));
            dataPoints.Add(new DataPoint("Dec", countDezCao()));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();

        }

        


        #region Eventos
        public int countJan()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 1)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countFev()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 2)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countMar()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 3)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countAbri()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 4)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countMaio()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 5)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countJun()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 6)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countJul()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 7)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countAgo()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 8)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countSet()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 9)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countOut()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 10)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countNov()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 11)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countDez()
        {

            var StreetCrimes = this._context.Evento
      .Where(x => x.Data.Month == 12)
      .GroupBy(s => new { district = s.Nome, date = s.Data.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        #endregion

        #region Caes Adotados
        public int countJanCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 1)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }
        public int countFevCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 2)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }

        public int countMarCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 3)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }

        public int countAbrilCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 4)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }

        public int countMaioCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 5)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }

        public int countJunCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 6)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }

        public int countJulCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 7)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }

        public int countAgoCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 8)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }

        public int countSetCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 9)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }

        public int countOutCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 10)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }

        public int countNovCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 11)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }

        public int countDezCaesAdoptados()
        {

            var caesAdoptados = this._context.Adocao
      .Where(x => x.DataAdocao.Month == 12)
      .GroupBy(s => new { district = s.Nome, date = s.DataAdocao.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return caesAdoptados.Count();

        }



        #endregion


        #region Caes do Albergue
        public int countJanCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 1)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countFevCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 2)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countMarCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 3)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countAbriCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 4)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countMaioCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 5)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countJunCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 6)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countJulCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 7)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countAgoCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 8)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countSetCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 9)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countOutCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 10)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countNovCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 11)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }

        public int countDezCao()
        {

            var StreetCrimes = this._context.Cao
      .Where(x => x.DataDeEntrada.Month == 12)
      .GroupBy(s => new { district = s.Nome, date = s.DataDeEntrada.Month })
      .Select(x => new { count = x.Count(), district = x.Key.district, date = x.Key.date })
      .ToList();

            return StreetCrimes.Count();

        }
        #endregion

    }

}
