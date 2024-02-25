<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="workout.aspx.cs" Inherits="ItayProject.WebPages.workout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <main>
        <section class="workout">
            <h1>Workout Routines</h1>
            <p>Choose from a variety of workout routines designed to help you achieve your fitness goals.</p>
            <div class="workout-routine">
                <h2>Beginner Full-Body Workout</h2>
                <p>Get started with this beginner-friendly full-body workout that requires no equipment.</p>
                <button class="show-details">Show Details</button>
                <div class="details">
                    <ul>
                        <li><strong>Warm-Up:</strong> Start with 5-10 minutes of light cardio (e.g., jogging in place, jumping jacks, or marching in place) to raise your heart rate and warm up your muscles.</li>
                        <li><strong>1. Push-Ups</strong>
                            <ul>
                                <li>3 sets of 5-10 repetitions</li>
                            </ul>
                        </li>
                        <li><strong>2. Bodyweight Squats</strong>
                            <ul>
                                <li>3 sets of 10-15 repetitions</li>
                            </ul>
                        </li>
                        <li><strong>3. Plank</strong>
                            <ul>
                                <li>Hold for 20-30 seconds (increase duration as you progress)</li>
                            </ul>
                        </li>
                        <li><strong>4. Glute Bridges</strong>
                            <ul>
                                <li>3 sets of 10-15 repetitions</li>
                            </ul>
                        </li>
                        <li><strong>5. Bird Dogs</strong>
                            <ul>
                                <li>3 sets of 8-10 repetitions per side</li>
                            </ul>
                        </li>
                        <li><strong>Cool Down:</strong> Finish with 5-10 minutes of stretching exercises to improve flexibility and prevent muscle soreness.</li>
                    </ul>
                    
                </div>
            </div>
            <div class="workout-routine">
                <h2>Intermediate Strength Training</h2>
                <p>Take your fitness to the next level with this intermediate strength training routine.</p>
                <button class="show-details">Show Details</button>
                <div class="details">
                    <ul>
                        <li><strong>Warm-Up:</strong> Start with 5-10 minutes of light cardio or dynamic stretching to prepare your body for the workout.</li>
                        <li><strong>1. Bench Press</strong>
                            <ul>
                                <li>4 sets of 8-10 repetitions</li>
                            </ul>
                        </li>
                        <li><strong>2. Squats</strong>
                            <ul>
                                <li>4 sets of 8-10 repetitions</li>
                            </ul>
                        </li>
                        <li><strong>3. Deadlifts</strong>
                            <ul>
                                <li>3 sets of 6-8 repetitions</li>
                            </ul>
                        </li>
                        <li><strong>4. Pull-Ups</strong>
                            <ul>
                                <li>3 sets of as many reps as possible (AMRAP)</li>
                            </ul>
                        </li>
                        <li><strong>5. Dumbbell Rows</strong>
                            <ul>
                                <li>3 sets of 10-12 repetitions per arm</li>
                            </ul>
                        </li>
                        <li><strong>6. Overhead Press</strong>
                            <ul>
                                <li>3 sets of 8-10 repetitions</li>
                            </ul>
                        </li>
                        <li><strong>7. Plank</strong>
                            <ul>
                                <li>3 sets, holding for 30-60 seconds each</li>
                            </ul>
                        </li>
                        <li><strong>Cool Down:</strong> Finish with 5-10 minutes of static stretching to improve flexibility and reduce muscle tension.</li>
                    </ul>
                    
                </div>
            </div>
        </section>
    </main>
    <script src="../JS/workout.js"></script>
</asp:Content>
