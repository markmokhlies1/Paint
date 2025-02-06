namespace Paint.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Paint.Model;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]  // Equivalent of @CrossOrigin in Spring
    public class DemoController : ControllerBase
    {
        private readonly DemoService _service;

        public DemoController(DemoService service)
        {
            _service = service;
        }

        [HttpGet("create/{type}/{json}")]
        public async Task<ActionResult<string>> Create(string type, string json)
        {
            try
            {
                var result = await _service.CreateAsync(type, json);
                return Ok(result);
            }
            catch (JsonProcessingException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CloneNotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("update/{id}/{json}")]
        public async Task<ActionResult<string>> Update(string id, string json)
        {
            try
            {
                var result = await _service.UpdateAsync(id, json);
                return Ok(result);
            }
            catch (JsonProcessingException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CloneNotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("redo")]
        public async Task<ActionResult<string>> Redo()
        {
            try
            {
                var result = await _service.RedoAsync();
                return Ok(result);
            }
            catch (JsonProcessingException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CloneNotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("undo")]
        public async Task<ActionResult<string>> Undo()
        {
            try
            {
                var result = await _service.UndoAsync();
                return Ok(result);
            }
            catch (JsonProcessingException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("clear")]
        public async Task<ActionResult> Clear()
        {
            await _service.ClearAsync();
            return NoContent();
        }

        [HttpGet("print")]
        public ActionResult<Dictionary<string, Shapes>> Print()
        {
            var result = _service.Print();
            return Ok(result);
        }

        [HttpGet("save/{path}")]
        public async Task<ActionResult<bool>> SaveJson(string path)
        {
            try
            {
                await _service.SaveXmlAsync(path + ".xml");
                var result = await _service.SaveJsonAsync(path + ".json");
                return Ok(result);
            }
            catch (IOException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("loadJson/{path}")]
        public async Task<ActionResult<string[]>> LoadJson(string path)
        {
            try
            {
                var result = await _service.LoadJsonAsync(path);
                return Ok(result);
            }
            catch (IOException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ParseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CloneNotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("loadXML/{path}")]
        public async Task<ActionResult<string[]>> LoadXml(string path)
        {
            try
            {
                var result = await _service.LoadXmlAsync(path);
                return Ok(result);
            }
            catch (IOException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ParseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CloneNotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
