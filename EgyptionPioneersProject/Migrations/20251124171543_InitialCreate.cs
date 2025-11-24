using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgyptionPioneersProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Dis_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dis_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Dis_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dis_Severity_Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Dis_Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    D_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    D_Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    D_Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    D_Specialization = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    D_Experience = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    D_Working_Hour = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.D_Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    P_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    P_Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    P_Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    P_Age = table.Column<int>(type: "int", nullable: false),
                    Skin_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Medical_History = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.P_Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Pr_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pr_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Pr_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pr_Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Pr_Stock = table.Column<int>(type: "int", nullable: false),
                    Pr_Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Pr_Id);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    S_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.S_Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    T_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    T_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_Duration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.T_Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Ap_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    A_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    A_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: false),
                    D_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Ap_Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_D_Id",
                        column: x => x.D_Id,
                        principalTable: "Doctors",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Patients",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatbotSessions",
                columns: table => new
                {
                    Cs_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cs_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cs_Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: false),
                    Dis_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatbotSessions", x => x.Cs_Id);
                    table.ForeignKey(
                        name: "FK_ChatbotSessions_Diseases_Dis_Id",
                        column: x => x.Dis_Id,
                        principalTable: "Diseases",
                        principalColumn: "Dis_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatbotSessions_Patients_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Patients",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Md_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Md_Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Md_Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Md_Diagnoses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: false),
                    D_Id = table.Column<int>(type: "int", nullable: false),
                    Dis_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Md_Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Diseases_Dis_Id",
                        column: x => x.Dis_Id,
                        principalTable: "Diseases",
                        principalColumn: "Dis_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Doctors_D_Id",
                        column: x => x.D_Id,
                        principalTable: "Doctors",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patients_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Patients",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    N_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    N_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    N_Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: true),
                    D_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.N_Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Doctors_D_Id",
                        column: x => x.D_Id,
                        principalTable: "Doctors",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Notifications_Patients_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Patients",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    O_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    O_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    O_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    O_Total_Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.O_Id);
                    table.ForeignKey(
                        name: "FK_Orders_Patients_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Patients",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disease_Symptoms",
                columns: table => new
                {
                    Dis_Id = table.Column<int>(type: "int", nullable: false),
                    S_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease_Symptoms", x => new { x.Dis_Id, x.S_Id });
                    table.ForeignKey(
                        name: "FK_Disease_Symptoms_Diseases_Dis_Id",
                        column: x => x.Dis_Id,
                        principalTable: "Diseases",
                        principalColumn: "Dis_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disease_Symptoms_Symptoms_S_Id",
                        column: x => x.S_Id,
                        principalTable: "Symptoms",
                        principalColumn: "S_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disease_Treatments",
                columns: table => new
                {
                    Dis_Id = table.Column<int>(type: "int", nullable: false),
                    T_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease_Treatments", x => new { x.Dis_Id, x.T_Id });
                    table.ForeignKey(
                        name: "FK_Disease_Treatments_Diseases_Dis_Id",
                        column: x => x.Dis_Id,
                        principalTable: "Diseases",
                        principalColumn: "Dis_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disease_Treatments_Treatments_T_Id",
                        column: x => x.T_Id,
                        principalTable: "Treatments",
                        principalColumn: "T_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatment_Products",
                columns: table => new
                {
                    T_Id = table.Column<int>(type: "int", nullable: false),
                    Pr_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment_Products", x => new { x.T_Id, x.Pr_Id });
                    table.ForeignKey(
                        name: "FK_Treatment_Products_Products_Pr_Id",
                        column: x => x.Pr_Id,
                        principalTable: "Products",
                        principalColumn: "Pr_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatment_Products_Treatments_T_Id",
                        column: x => x.T_Id,
                        principalTable: "Treatments",
                        principalColumn: "T_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Products",
                columns: table => new
                {
                    O_Id = table.Column<int>(type: "int", nullable: false),
                    Pr_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Products", x => new { x.O_Id, x.Pr_Id });
                    table.ForeignKey(
                        name: "FK_Order_Products_Orders_O_Id",
                        column: x => x.O_Id,
                        principalTable: "Orders",
                        principalColumn: "O_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Products_Products_Pr_Id",
                        column: x => x.Pr_Id,
                        principalTable: "Products",
                        principalColumn: "Pr_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_D_Id",
                table: "Appointments",
                column: "D_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_P_Id",
                table: "Appointments",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChatbotSessions_Dis_Id",
                table: "ChatbotSessions",
                column: "Dis_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChatbotSessions_P_Id",
                table: "ChatbotSessions",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Disease_Symptoms_S_Id",
                table: "Disease_Symptoms",
                column: "S_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Disease_Treatments_T_Id",
                table: "Disease_Treatments",
                column: "T_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_D_Id",
                table: "MedicalRecords",
                column: "D_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_Dis_Id",
                table: "MedicalRecords",
                column: "Dis_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_P_Id",
                table: "MedicalRecords",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_D_Id",
                table: "Notifications",
                column: "D_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_P_Id",
                table: "Notifications",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Products_Pr_Id",
                table: "Order_Products",
                column: "Pr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_P_Id",
                table: "Orders",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_Products_Pr_Id",
                table: "Treatment_Products",
                column: "Pr_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ChatbotSessions");

            migrationBuilder.DropTable(
                name: "Disease_Symptoms");

            migrationBuilder.DropTable(
                name: "Disease_Treatments");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Order_Products");

            migrationBuilder.DropTable(
                name: "Treatment_Products");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
