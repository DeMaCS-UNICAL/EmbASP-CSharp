using it.unical.mat.parsers.asp.clingo;
using it.unical.mat.parsers.asp.dlv;
using it.unical.mat.parsers.asp.dlv2;
using it.unical.mat.parsers.asp.dlvhex;

namespace it.unical.mat.parsers.asp
{
    public static class DatalogSolversParser
    {
        public static void ParseIDLV(IDatalogDataCollection minimalModels, string atomsList, bool two_stageParsing)
        {
            IDLVParserBaseVisitorImplementation.Parse(minimalModels, atomsList, two_stageParsing);
        }

    }
}