using Microsoft.VisualBasic;
using MoInvoices.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoInvoices.PDF.Template
{
    public static class InvoiceVAT
    {
        public static Task<string> GetInvoiceVAT(InvoiceDTO invoice)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"
                     <html>
                            <head>
                            </head>
                            <body>
<style type='text/css'>table {{ padding: 0px; margin: auto; border-collapse: collapse; }}
td {{ padding: 4px; margin: 0px; font-size:12pt; line-height: 1.2; }}.title {{ text-align:center; font-weight: 400; font-size:14pt; line-height: 0.8; }}.subtitle {{ text-align:center; font-size:12pt; line-height: 1.2; padding-top: 2px; }}td .body {{ text-align:center; line-height: 1.2; font-weight: 400; }}td .head {{ text-align:center; border-top: 0.5px solid black; background-color: #e2e2e2; font-weight: 300; font-size:12pt; padding: -1 0 2 0; line-height: 0.8; }}td .body1 {{ text-align:left; font-weight: 300; line-height: 1.1; }}td .head1 {{ text-align:center; border-top: 0.5px solid black; background-color: #e2e2e2; font-weight: 400; font-size:12pt; padding: -1 0 2 0; line-height: 0.8; }}#table th {{ padding: 2 6 6 6; text-align:center; border-left: 0.5px solid black; border-right: 0.5px solid black; border-top: 0.5px solid black; background-color: #e2e2e2; font-weight: 400; font-size:14px; line-height: 1.2; }}#table th.no1 {{ padding: 2 6 6 6; text-align:center; border: 0px; background-color: #ffffff; font-weight: 400; font-size:14px; line-height: 1.2; }}#table td {{ padding: 2 6 6 6; border-left: 0.5px solid black; border-right: 0.5px solid black; border-bottom: 0.5px solid black; line-height: 1.2; font-size:12pt; }}#table td.bold {{font-weight: 400; border: 0.5px solid black; background-color: #e2e2e2; }}#table td.bold1 {{font-weight: 400; }}#table tr.pad td {{padding: 0 6 6 6; }}#table td small {{font-size:8pt; color: #575757; }}#table td.no {{border: 0px; text-align:center; font-size:8pt; line-height: 1.2; }}#table td.no1 {{border: 0px; text-align:right; font-size:12pt; font-weight: 400; padding-top: 4px; }}#table td.no2 {{border: 0px; font-size:12pt; line-height: 1.2; border: 0px; }}#table td.b {{border: 0px; text-align:right; font-weight: 400; font-size:12pt; }}.top td {{border-top: 0.5px solid black; }}#table1 td {{border-top: 0.5px solid black; line-height: 1.2; vertical-align: baseline; font-size:12pt; font-weight: 300; border-collapse: separate; table-layout: fixed;}}#table1 tr td:first-child {{white-space: nowrap; padding: 3 0 3 0; }}#table1 tr td:last-child {{text-align:left; width: 100%; padding: 3 0 3 8; }}#table1 tr td:first-child.pad {{padding: 3 0 3 0; white-space: normal; }}#table1 b {{font-weight: 400; font-size:12pt; }}#table2 td {{padding: 3 5 5 5; border-left: 0px; border-right: 0px; border-bottom: 0.5px solid black; line-height: 1.2; font-size:12pt; font-weight: 400; }}#table2 td.no {{border: 0px; text-align:center; font-size:8pt; line-height: 1.2; font-weight: 300; }}#table3 td {{border-top: 0.5px solid black; line-height: 1.2; vertical-align: baseline; font-size:12pt; font-weight: 300; border-collapse: separate; table-layout: fixed; padding: 3 0 3 0; }}#table3 b {{font-weight: 400; font-size:12pt; }}#table4 td {{font-size:14px; font-weight: 400; padding: 0px 0px 8px 0px; }}#uwagi td {{padding: 2 0 5 0; border-top: 0.5px solid black; font-size:12pt; line-height: 1.2; vertical-align: baseline; }}#uwagi td.no {{ padding: 2 0 5 0; border: 0px; font-size:12pt; line-height: 1.2; vertical-align: baseline; }}.nowrap {{ white-space: nowrap; }}
                                 </style>  
                        <div class='header'><h1>Faktura VAT</h1></div>

<table width='100%' cellpadding='0' cellspacing='0'>
    <tbody>
        <tr>
            <td width='50%' valign='' align=''></td>    
            <td width='6%'></td>
            <td width='44%' valign='top'>
            <table width='100%' cellpadding='0' cellspacing='0'>
                <tbody>
                <tr>
                    <td class='head'>Miejsce wystawienia</td>
                    </tr>
                <tr>
                    <td class='body'>{0}</td>
                </tr>
                <tr>
                    <td style='font-size:10px;'>&nbsp;</td>
                </tr>
                <tr>
                    <td class='head'>Data wystawienia</td>
                </tr>
                <tr>
                    <td class='body'>{1}</td>
                </tr>
                <tr>
                    <td style='font-size:10px;'>&nbsp;</td>
                </tr>
                <tr>
                    <td class='head'>Data sprzedaży</td>
                </tr>
                <tr>
                    <td class='body'>{2}</td>
                </tr>
                </tbody>
                </table>
                </td>
            </tr>
        </tbody>
</table>", invoice.CityOfIssue, invoice.IssueDate.ToShortDateString(), invoice.SellDate.ToShortDateString());
            sb.AppendFormat(@"
<table width='100%' cellpadding='0' cellspacing='0'>
    <tbody>
    <tr>
        <td width='46%' valign='top'>
            <table width='100%' cellpadding='0' cellspacing='0'>
                <tbody>
                    <tr>
                        <td class='head1'>Sprzedawca</td>
                        </tr>
                    <tr>
                        <td class='body1'>{0}
                            <br>NIP: {1}
                            <br>ul. {2}
                            <br>{3} {4}
                        </td>                
                    </tr>
                </tbody>
            </table>
        </td>
        <td width='8%'></td>
        <td width='46%' valign='top'>
        <table width='100%' cellpadding='0' cellspacing='0'>
            <tbody>
            <tr>
                <td class='head1'>Nabywca</td>
                </tr>
            <tr>
                <td class='body1'>{5}
                <br>NIP: {6}
                <br>ul. {7}
                <br>{8} {8}
                    </td></tr></tbody></table></td></tr></tbody></table>", invoice.Vendor.Name, invoice.Vendor.NIP, invoice.Vendor.Street, invoice.Vendor.PostalCode, invoice.Vendor.City, invoice.Purchaser.Name, invoice.Purchaser.NIP, invoice.Purchaser.Street, invoice.Purchaser.PostalCode, invoice.Purchaser.City);

            sb.Append(@"<table align='center'>
                                    <tr>
                                        <th>Nazwa</th>
                                        <th>Jm.</th>
                                        <th>Ilość</th>
                                        <th>Cena Netto</th>
                                        <th>Wartość Netto</th>
                                        <th>Stawka Vat</th>
                                        <th>Kwota VAT</th>
                                        <th>Wartość brutto</th>
                                    </tr>");
            foreach (var row in invoice.Services)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                  </tr></table>
                            </body>
                        </html>", row.ServiceName, row.JM, row.NetPrice, row.NetWorth, row.VatRate, row.VatAmount, row.GrossValue);
            }

            return Task.FromResult(sb.ToString());
        }
    }
}
