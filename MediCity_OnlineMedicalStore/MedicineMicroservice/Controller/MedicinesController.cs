using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediCity_OnlineMedicalStore.MedicineMicroservice.BusinessLayer.ModelDto;
using MediCity_OnlineMedicalStore.MedicineMicroservice.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediCity_OnlineMedicalStore.MedicineMicroservice.Controller
{
    [ApiController]
    [Route("api/medicines")]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicines()
        {
            try
            {
                var medicines = await _medicineService.GetAllMedicines();
                return Ok(medicines);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                return StatusCode(500, "An error occurred while retrieving medicines.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicineById(int id)
        {
            try
            {
                var medicine = await _medicineService.GetMedicineById(id);
                if (medicine == null)
                {
                    return NotFound();
                }
                return Ok(medicine);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                return StatusCode(500, "An error occurred while retrieving the medicine.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicine([FromBody] MedicineDto medicineDto)
        {
            try
            {
                var addedMedicine = await _medicineService.AddMedicine(medicineDto);
                return CreatedAtAction(nameof(GetMedicineById), new { id = addedMedicine.Id }, addedMedicine);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                return StatusCode(500, "An error occurred while adding the medicine.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicine(int id, [FromBody] MedicineDto medicineDto)
        {
            try
            {
                var updatedMedicine = await _medicineService.UpdateMedicine(id, medicineDto);
                return Ok(updatedMedicine);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                return StatusCode(500, "An error occurred while updating the medicine.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            try
            {
                var result = await _medicineService.DeleteMedicine(id);
                if (result)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                return StatusCode(500, "An error occurred while deleting the medicine.");
            }
        }
    }
}
