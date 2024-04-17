# Orbit

### Construct, manipulate, and visualize graph structures.

A Unity package that describes graphs in a graph-theoretical sense.

## Features

- Can construct graphs directly with an Adjacency Matrix.
- Can construct graphs with an Adjacency Function.
- Has TestGraph/Edge to play around with.
  - Will probably be moved in the future to Samples or something.

## (Planned) Features

- Validates graphs when constructed with an Adjacency Function/Matrix.
- Iso/automorphisms.
  - Essentially, can check if two graphs are same if they have the same adjacency matrix or if you feed the equality function an isomorphism that is valid.
  - Don't really know what else I want to do with them.

## Not a priority, but have crossed my mind

- Finding cliques.
- k-colorings.
- Checking if graphs are planar and making planar representation.

## To-do

- [ ] Move non-MonoBehaviour library classes somewhere better.
  - Right now, it kind of looks like the library classes are attachable Components.
- [ ] Consolidate Adjacency Matrix into Graph.
  - Currently, Graphs are just loose wrappers around Adjacency Matrices.
  - Hopefully, they won't be in the future as I add more Graph-specific things.
- [ ] Make better edges.
  - Hopefully, they'll eventually be lines instead of cubes.