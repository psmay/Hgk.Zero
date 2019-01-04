# Hgk.Zero [![Build Status](https://travis-ci.com/psmay/Hgk.Zero.svg?branch=master)](https://travis-ci.com/psmay/Hgk.Zero) [![MIT (Expat) license](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

This is a library primarily for use with C# that provides utilities I
generally don't want to be without. Currently, this consists of:

*   Hgk.Zero.Options, which provides LINQ-enabled enumerable containers
    which contain zero elements or one element, enabling a more fluent
    alternative to `TryGetValue`/`TryParse` methods and
    `ElementAt`/`First`/`Last`/`Single` filters.
*   Hgk.Zero.Strings, which makes the functionality of the static
    `String.Concat()` and `String.Join()` methods available as extension
    methods on strings and enumerables.

## Ulterior motives

As much as this project is about the stated functionality, it's also
intended to serve as an exercise for me in documenting code, writing
unit tests, utilizing CI/CD technologies, and, ultimately, supporting
the software for anyone with the bravado to actually use it.

# LICENSE

You may use this software under the terms of the Expat License (aka the
MIT License, as published by OSI). Refer to the file LICENSE for the
exact terms.
