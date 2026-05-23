using FluentAssertions;
using RestWithASPNET10Erudio.Data.Converter.Impl.V2;
using RestWithASPNET10Erudio.Data.DTO.V2;
using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Tests
{
    public class PersonConverterTests
    {

        private readonly PersonConverter _converter;

        public PersonConverterTests()
        {
            _converter = new PersonConverter();
        }



        // PersonDTO to Person conversion tests
        [Fact]
        public void Parse_ShouldConvertPersonDTOToPerson()
        {
            // Arrange: prepare the data, objects, and dependecies required for the test
            var dto = new PersonDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                BirthDay = new DateTime(1869, 10, 2)
            };

            var expectedPerson = new Person
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male"
            };

            // Act: execute the method or functionality under test
            var person = _converter.Parse(dto);
            
            // Assert: verify that the result matches the expected outcome
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Address.Should().Be(expectedPerson.Address);
            person.Gender.Should().Be(expectedPerson.Gender);
            person.Should()
                .BeEquivalentTo(expectedPerson);
        }

        // PersonDTO to Person conversion tests
        [Fact]
        public void Parse_nullPersonDTOShouldReturnNull()
        {
            // Arrange: prepare the data, objects, and dependecies required for the test
            PersonDTO dto = null;

            // Act: execute the method or functionality under test
            var person = _converter.Parse(dto);

            // Assert: verify that the result matches the expected outcome
            person.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonDTOListToPersonList()
        {
            // Arrange: prepare the data, objects, and dependecies required for the test
            var dtoList = new List<PersonDTO>
            {
                new PersonDTO
                {
                    Id = 1,
                    FirstName = "Mahatma",
                    LastName = "Gandhi",
                    Address = "Porbandar - India",
                    Gender = "Male",
                    BirthDay = new DateTime(1869, 10, 2)
                },
                new PersonDTO
                {
                    Id = 2,
                    FirstName = "Indira",
                    LastName = "Gandhi",
                    Address = "Allahabad - India",
                    Gender = "Female",
                    BirthDay = new DateTime(1917, 11, 12)
                }
            };

            var expectedPersonList = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Mahatma",
                    LastName = "Gandhi",
                    Address = "Porbandar - India",
                    Gender = "Male"
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Indira",
                    LastName = "Gandhi",
                    Address = "Allahabad - India",
                    Gender = "Female",
                }
            };

            // Act: execute the method or functionality under test
            var personList = _converter.ParseList(dtoList);

            // Assert: verify that the result matches the expected outcome
            personList.Should().NotBeNull();
            personList.Count.Should().Be(expectedPersonList.Count);
            for (int i = 0; i < personList.Count; i++)
            {
                personList[i].Should().BeEquivalentTo(expectedPersonList[i]);
            }



            personList[0].Should().BeEquivalentTo(new Person
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male"
                //BirthDay = new DateTime(
            });

            personList[1].Should().BeEquivalentTo(new Person
            {
                Id = 2,
                FirstName = "Indira",
                LastName = "Gandhi",
                Address = "Allahabad - India",
                Gender = "Female"
                //BirthDay = new DateTime(
            });

            personList[0].FirstName.Should().Be("Mahatma");
            personList[1].FirstName.Should().Be("Indira");
            personList[1].LastName.Should().Be("Gandhi");

        }

        [Fact]
        public void Parse_NullListPersonShouldReturnNull()
        {
            List<PersonDTO> personDTOList = null;
            var persons = _converter.ParseList(personDTOList);
            persons.Should().BeNull();
        }


        // PersonDTO to Person conversion tests
        [Fact]
        public void Parse_ShouldConvertPersonToPersonDTO()
        {
            // Arrange: prepare the data, objects, and dependecies required for the test
            var person = new Person
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
              
            };

            var expectedDTO = new PersonDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                BirthDay = new DateTime(1869, 10, 2)
            };

            // Act: execute the method or functionality under test
            var dto = _converter.Parse(person);

            // Assert: verify that the result matches the expected outcome
            dto.Should().NotBeNull();
            dto.Id.Should().Be(expectedDTO.Id);
            dto.FirstName.Should().Be(expectedDTO.FirstName);
            dto.LastName.Should().Be(expectedDTO.LastName);
            dto.Address.Should().Be(expectedDTO.Address);
            dto.Gender.Should().Be(expectedDTO.Gender);
            
            dto.Should()
                .BeEquivalentTo(expectedDTO, 
                options => options.Excluding(dto => dto.BirthDay));
        }

        // Person to PersonDTO conversion tests
        [Fact]
        public void Parse_nullPersonShouldReturnNull()
        {
            // Arrange: prepare the data, objects, and dependecies required for the test
            Person person = null;

            // Act: execute the method or functionality under test
            var dto = _converter.Parse(person);

            // Assert: verify that the result matches the expected outcome
            dto.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonListToPersonListDTO()
        {
            // Arrange: prepare the data, objects, and dependecies required for the test
            var personList = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Mahatma",
                    LastName = "Gandhi",
                    Address = "Porbandar - India",
                    Gender = "Male",
                },
                    
                new Person
                {
                    Id = 2,
                    FirstName = "Indira",
                    LastName = "Gandhi",
                    Address = "Allahabad - India",
                    Gender = "Female",
                }
            };

            var expectedPersonDTOList = new List<PersonDTO>
            {
                new PersonDTO
                {
                    Id = 1,
                    FirstName = "Mahatma",
                    LastName = "Gandhi",
                    Address = "Porbandar - India",
                    Gender = "Male",
                    BirthDay = new DateTime(1869, 10, 2)
                },
                new PersonDTO
                {
                    Id = 2,
                    FirstName = "Indira",
                    LastName = "Gandhi",
                    Address = "Allahabad - India",
                    Gender = "Female",
                    BirthDay = new DateTime(1917, 11, 12)
                }
            };

            // Act: execute the method or functionality under test
            var personDTOList = _converter.ParseList(personList);

            // Assert: verify that the result matches the expected outcome
            personDTOList.Should().NotBeNull();
            personDTOList.Count.Should().Be(expectedPersonDTOList.Count);
            personDTOList[0].Should().BeEquivalentTo(new PersonDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                //BirthDay = new DateTime(1869, 10, 2)
                BirthDay = null
            });

            personDTOList[1].Should().BeEquivalentTo(new PersonDTO
            {
                Id = 2,
                FirstName = "Indira",
                LastName = "Gandhi",
                Address = "Allahabad - India",
                Gender = "Female",
                //BirthDay = new DateTime(1917, 11, 12)
                BirthDay = null 
            });

            personDTOList[0].FirstName.Should().Be("Mahatma");
            personDTOList[1].FirstName.Should().Be("Indira");
            personDTOList[1].LastName.Should().Be("Gandhi");

        }

        [Fact]
        public void Parse_NullListPersonDTOShouldReturnNull()
        {
            List<Person> personList = null;
            var personDTOList = _converter.ParseList(personList);
            personDTOList.Should().BeNull();
        }

    }
}
