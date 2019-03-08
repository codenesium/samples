import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UsersMapper from './usersMapper';
import UsersViewModel from './usersViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {BadgesTableComponent} from '../shared/badgesTable'
	import {CommentsTableComponent} from '../shared/commentsTable'
	import {PostsTableComponent} from '../shared/postsTable'
	import {VotesTableComponent} from '../shared/votesTable'
	import {PostHistoryTableComponent} from '../shared/postHistoryTable'
	



interface UsersDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UsersDetailComponentState {
  model?: UsersViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class UsersDetailComponent extends React.Component<
UsersDetailComponentProps,
UsersDetailComponentState
> {
  state = {
    model: new UsersViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Users + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Users +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.UsersClientResponseModel;

          console.log(response);

          let mapper = new UsersMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    } 
  
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div>
							<h3>About Me</h3>
							<p>{String(this.state.model!.aboutMe)}</p>
						 </div>
					   						 <div>
							<h3>Account</h3>
							<p>{String(this.state.model!.accountId)}</p>
						 </div>
					   						 <div>
							<h3>Age</h3>
							<p>{String(this.state.model!.age)}</p>
						 </div>
					   						 <div>
							<h3>Creation Date</h3>
							<p>{String(this.state.model!.creationDate)}</p>
						 </div>
					   						 <div>
							<h3>Display Name</h3>
							<p>{String(this.state.model!.displayName)}</p>
						 </div>
					   						 <div>
							<h3>Down Vote</h3>
							<p>{String(this.state.model!.downVote)}</p>
						 </div>
					   						 <div>
							<h3>Email Hash</h3>
							<p>{String(this.state.model!.emailHash)}</p>
						 </div>
					   						 <div>
							<h3>Last Access Date</h3>
							<p>{String(this.state.model!.lastAccessDate)}</p>
						 </div>
					   						 <div>
							<h3>Location</h3>
							<p>{String(this.state.model!.location)}</p>
						 </div>
					   						 <div>
							<h3>Reputation</h3>
							<p>{String(this.state.model!.reputation)}</p>
						 </div>
					   						 <div>
							<h3>Up Vote</h3>
							<p>{String(this.state.model!.upVote)}</p>
						 </div>
					   						 <div>
							<h3>View</h3>
							<p>{String(this.state.model!.view)}</p>
						 </div>
					   						 <div>
							<h3>Website Url</h3>
							<p>{String(this.state.model!.websiteUrl)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>Badges</h3>
            <BadgesTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.state.model!.id + '/' + ApiRoutes.Badges}
			/>
         </div>
			 <div>
            <h3>Comments</h3>
            <CommentsTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.state.model!.id + '/' + ApiRoutes.Comments}
			/>
         </div>
			 <div>
            <h3>Posts</h3>
            <PostsTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.state.model!.id + '/' + ApiRoutes.Posts}
			/>
         </div>
			 <div>
            <h3>Votes</h3>
            <VotesTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.state.model!.id + '/' + ApiRoutes.Votes}
			/>
         </div>
			 <div>
            <h3>PostHistory</h3>
            <PostHistoryTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.state.model!.id + '/' + ApiRoutes.PostHistory}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedUsersDetailComponent = Form.create({ name: 'Users Detail' })(
  UsersDetailComponent
);

/*<Codenesium>
    <Hash>66d5e0a5abce39abbfb34fec4e6ef2e1</Hash>
</Codenesium>*/