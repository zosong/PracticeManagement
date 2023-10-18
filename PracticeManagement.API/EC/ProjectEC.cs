using PracticeManagement.API.Database;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;

namespace PracticeManagement.API.EC
{
    public class ProjectEC
    {
        public ProjectDTO? Get(int id)
        {
            var project = Filebase.Current.Projects.FirstOrDefault(p => p.Id == id);
            return project != null ? new ProjectDTO(project) : null;
        }

        public Project AddOrUpdate(Project project)
        {
            return Filebase.Current.AddOrUpdate(project);
        }

        public ProjectDTO? Delete(int id)
        {
            var projectToDelete = Filebase.Current.Projects.FirstOrDefault(p => p.Id == id);
            if (projectToDelete != null)
            {
                Filebase.Current.Projects.Remove(projectToDelete);
            }
            return projectToDelete != null ?
                new ProjectDTO(projectToDelete)
                : null;
        }

        public IEnumerable<ProjectDTO> Search(string query = "")
        {
            return Filebase.Current.Projects
                .Where(c => c.LongName.ToUpper()
                    .Contains(query.ToUpper()))
                .Take(1000)
                .Select(c => new ProjectDTO(c));
        }
    }
}
