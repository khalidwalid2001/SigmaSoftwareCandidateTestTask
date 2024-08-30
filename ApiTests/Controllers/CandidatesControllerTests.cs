using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Api.Controllers;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tests
{
    [TestClass()]
    public class CandidatesControllerTests
    {
        private Mock<ICandidateService> _candidateServiceMock;
        private CandidatesController _controller;

        [TestInitialize]
        public void Setup()
        {
            _candidateServiceMock = new Mock<ICandidateService>();

            _controller = new CandidatesController(_candidateServiceMock.Object);
        }

        [TestMethod()]
        public void SaveCandidateTest_Successful()
        {
            var candidateDto = new CandidateDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890"
            };

            _candidateServiceMock.Setup(service => service.UpsertCandidate(candidateDto))
                .Verifiable();

            var result = _controller.SaveCandidate(candidateDto) as OkResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            _candidateServiceMock.Verify(service => service.UpsertCandidate(candidateDto), Times.Once);
        }

        [TestMethod()]
        public void SaveCandidateTest_InvalidModel_EmailIsNull()
        {
            // Arrange
            var candidateDto = new CandidateDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = null,
                Comments = "Some comments"
            };


            var result = _controller.SaveCandidate(candidateDto) as BadRequestObjectResult;

            Assert.AreEqual(400, result.StatusCode);

            Assert.AreEqual("The Email field is required.", result.Value);
        }


    }
}
