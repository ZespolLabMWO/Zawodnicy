﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class SkiJumperController : Controller
    {
        private readonly ISkiJumperService _skiJumperService;

        public SkiJumperController(ISkiJumperService skiJumperService)
        {
            _skiJumperService = skiJumperService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            Console.WriteLine("BrowseAll");
            IEnumerable<SkiJumperDTO> z = await _skiJumperService.BrowseAll();
            return Json(z);
        }

        //https://localhost:5001/skijumper/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkiJumper(int id)
        {
            Console.WriteLine($"get: {id}");
            SkiJumperDTO z = await _skiJumperService.GetSkiJumper(id);
            return Json(z);
        }

        //https://localhost:5001/skijumper/filter?name=alan&country=ger
        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilter(string name, string country)
        {
            Console.WriteLine($"Get Filter: name: {name}, country: {country}");
            IEnumerable<SkiJumperDTO> z = await _skiJumperService.BrowseWithFilter(name, country);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkiJumper([FromBody] CreateSkiJumper skiJumper)
        {
            Console.WriteLine($"Post: id - {skiJumper.Id}");
            SkiJumperDTO z = await _skiJumperService.AddSkiJumper(skiJumper);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkiJumper([FromBody] UpdateSkiJumper skiJumper, int id)
        {
            Console.WriteLine($"Put: id {id}");
            SkiJumperDTO z = await _skiJumperService.UpdateSkiJumper(skiJumper, id);
            return Json(z);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkiJumper(int id)
        {
            Console.WriteLine($"Delete: id {id}");
            bool z = await _skiJumperService.DeleteSkiJumper(id);
            return Json(z);
        }

    }
}
