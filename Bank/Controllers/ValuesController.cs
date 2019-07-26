using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Bank.BusinessLogic;
using Bank.BusinessLogic.Entities;
using Bank.XmlModels;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IBatchRepository _repo;
        public ValuesController(IBatchRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // Регистрируем Кодировку, без него выдает ошибку

            string m_strFilePath = "http://www.cbr.ru/scripts/XML_daily.asp";
            var myXmlDocument = new XmlDocument();
            myXmlDocument.Load(m_strFilePath); // Читаем XML файл

            var sr = new StringReader(myXmlDocument.InnerXml);
            var serializer2 = new XmlSerializer(typeof(ValCurs));
            var response = (ValCurs)serializer2.Deserialize(sr); // Конвертируем в объект
            sr.Dispose();

            var kurs = response.Valute.FirstOrDefault(x => x.NumCode == id);

            if (kurs == null)
                return NotFound(); // Если не найдено, возвращаем ошибку
            else
                return Ok(kurs.Value + '/' + kurs.Nominal); // Если найдено, возвращаем курс с номиналом
        }

        [HttpGet("GetBatch")]
        public ActionResult GetBatch()
        {
            var batch = _repo.GetBatch(); // Ищем из базы данных

            var xsSubmit = new XmlSerializer(typeof(Batch));

            var stream = new MemoryStream();

            xsSubmit.Serialize(stream, batch);
            var buffer = stream.ToArray();

            stream.Dispose();

            var fileName = "BANK_" + DateTime.UtcNow.ToString("yyyyMMdd") + '_' + batch.CurentId + ".xml";

            return File(buffer, "application/xml", fileName);
        }
    }
}
