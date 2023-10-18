using Newtonsoft.Json;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;

        private List<ProjectDTO> projects;

        public List<ProjectDTO> Projects
        {
            get
            {
                //var response = new WebRequestHandler()
                //    .Get("/Project").Result;
                //var projects = JsonConvert.
                //    DeserializeObject<List<ProjectDTO>>(response);
                return projects ?? new List<ProjectDTO>();
            }
        }

        public IEnumerable<ProjectDTO> Search(string query)
        {
            return Projects
                .Where(c => c.LongName.ToUpper()
                    .Contains(query.ToUpper()));
        }

        public static ProjectService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectService();
                }
                return instance;
            }
        }

        private ProjectService()
        {
            var response = new WebRequestHandler()
                .Get("/Project").Result;
            projects = JsonConvert
                .DeserializeObject<List<ProjectDTO>>(response)??
                new List<ProjectDTO>();
        }


        public ProjectDTO? Get(int id)
        {
            return Projects.FirstOrDefault(p => p.Id == id);
        }

        public ProjectDTO? GetUpdate(int id)
        {
            return Projects.FirstOrDefault(p => p.ClientId == id);
        }




        public void Delete(int id)
        {
            var response = new WebRequestHandler()
                .Delete($"/Project/Delete/{id}").Result;
            if (response == "SUCCESS")
            {
                var projectToDelete = projects.FirstOrDefault(c => c.Id == id);
                if (projectToDelete != null)
                {
                    projects.Remove(projectToDelete);
                }
            }
        }


        public void AddOrUpdate(ProjectDTO p)
        {
            var response = new WebRequestHandler()
                .Post("/Project", p).Result;
            var myUpdatedProject = JsonConvert.DeserializeObject<ProjectDTO>(response);
            if (myUpdatedProject != null)
            {
                var existingProject = projects.FirstOrDefault(c => c.Id == myUpdatedProject.Id);
                if (existingProject == null)
                {
                    projects.Add(myUpdatedProject);
                }
                else
                {
                    var index = Projects.IndexOf(existingProject);
                    projects.RemoveAt(index);
                    projects.Insert(index, myUpdatedProject);
                }   
            }
        }

    }
}

