using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Game
{
    internal interface IMazeObject
    {
        char Icon {get;}    // The chape pf the maze object.
        bool IsSolid {get;} // Movement Block.
    }
}
