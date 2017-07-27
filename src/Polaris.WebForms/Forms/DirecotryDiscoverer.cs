using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Polaris.WebForms.Forms
{
    public class DirecotryDiscoverer
    {
        public List<ImageDir> Roots = new List<ImageDir>();

        public DirecotryDiscoverer(IEnumerable<string> files)
        {
            foreach (var item in files)
            {
                var fileInfo = new FileInfo(item);
                GetDir(fileInfo.Directory).Files.Add(fileInfo);
            }
        }

        public class ImageDir
        {
            public ImageDir(DirectoryInfo name)
            {
                DirectoryInfo = name;
                ImageDirs = new List<ImageDir>();
                Files = new List<FileInfo>();
            }
            public DirectoryInfo DirectoryInfo;

            public List<FileInfo> Files;

            public List<ImageDir> ImageDirs;

            public TreeNode ToTreeViewNode()
            {
                var node = new TreeNode(DirectoryInfo.Name);
                foreach (var item in ImageDirs)
                {
                    node.Nodes.Add(item.ToTreeViewNode());
                }
                foreach (var item in Files)
                {
                    var fileNode = new TreeNode(item.Name);
                    fileNode.ToolTipText = item.FullName;
                    node.Nodes.Add(fileNode);
                }
                return node;
            }
        }

        public void CompressRoots()
        {
            while (Roots.Count == 1 && Roots.SelectMany(x => x.Files).Count() == 0)
            {
                Roots = Roots.FirstOrDefault().ImageDirs;
            }
        }

        private ImageDir GetDir(DirectoryInfo dirInfo)
        {
            if (dirInfo.Parent == null)
            {
                var exisitng = Roots.FirstOrDefault(x => x.DirectoryInfo.FullName == dirInfo.FullName);
                if (exisitng == null)
                {
                    exisitng = new ImageDir(dirInfo);
                    Roots.Add(exisitng);
                }
                return exisitng;
            }
            else
            {
                var parent = GetDir(dirInfo.Parent);
                var exisitng = parent.ImageDirs.FirstOrDefault(x => x.DirectoryInfo.FullName == dirInfo.FullName);
                if (exisitng == null)
                {
                    exisitng = new ImageDir(dirInfo);
                    parent.ImageDirs.Add(exisitng);
                }
                return exisitng;
            }
        }
    }
}
