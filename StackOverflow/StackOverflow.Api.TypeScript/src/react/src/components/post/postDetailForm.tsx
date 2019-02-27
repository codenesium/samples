import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostMapper from './postMapper';
import PostViewModel from './postViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface PostDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostDetailComponentState {
  model?: PostViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PostDetailComponent extends React.Component<
PostDetailComponentProps,
PostDetailComponentState
> {
  state = {
    model: new PostViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Posts + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Posts +
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
          let response = resp.data as Api.PostClientResponseModel;

          console.log(response);

          let mapper = new PostMapper();

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
							<h3>AcceptedAnswerId</h3>
							<p>{String(this.state.model!.acceptedAnswerId)}</p>
						 </div>
					   						 <div>
							<h3>AnswerCount</h3>
							<p>{String(this.state.model!.answerCount)}</p>
						 </div>
					   						 <div>
							<h3>Body</h3>
							<p>{String(this.state.model!.body)}</p>
						 </div>
					   						 <div>
							<h3>ClosedDate</h3>
							<p>{String(this.state.model!.closedDate)}</p>
						 </div>
					   						 <div>
							<h3>CommentCount</h3>
							<p>{String(this.state.model!.commentCount)}</p>
						 </div>
					   						 <div>
							<h3>CommunityOwnedDate</h3>
							<p>{String(this.state.model!.communityOwnedDate)}</p>
						 </div>
					   						 <div>
							<h3>CreationDate</h3>
							<p>{String(this.state.model!.creationDate)}</p>
						 </div>
					   						 <div>
							<h3>FavoriteCount</h3>
							<p>{String(this.state.model!.favoriteCount)}</p>
						 </div>
					   						 <div>
							<h3>LastActivityDate</h3>
							<p>{String(this.state.model!.lastActivityDate)}</p>
						 </div>
					   						 <div>
							<h3>LastEditDate</h3>
							<p>{String(this.state.model!.lastEditDate)}</p>
						 </div>
					   						 <div>
							<h3>LastEditorDisplayName</h3>
							<p>{String(this.state.model!.lastEditorDisplayName)}</p>
						 </div>
					   						 <div>
							<h3>LastEditorUserId</h3>
							<p>{String(this.state.model!.lastEditorUserId)}</p>
						 </div>
					   						 <div>
							<h3>OwnerUserId</h3>
							<p>{String(this.state.model!.ownerUserId)}</p>
						 </div>
					   						 <div>
							<h3>ParentId</h3>
							<p>{String(this.state.model!.parentId)}</p>
						 </div>
					   						 <div>
							<h3>PostTypeId</h3>
							<p>{String(this.state.model!.postTypeId)}</p>
						 </div>
					   						 <div>
							<h3>Score</h3>
							<p>{String(this.state.model!.score)}</p>
						 </div>
					   						 <div>
							<h3>Tags</h3>
							<p>{String(this.state.model!.tag)}</p>
						 </div>
					   						 <div>
							<h3>Title</h3>
							<p>{String(this.state.model!.title)}</p>
						 </div>
					   						 <div>
							<h3>ViewCount</h3>
							<p>{String(this.state.model!.viewCount)}</p>
						 </div>
					   		  </div>
          {message}


        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedPostDetailComponent = Form.create({ name: 'Post Detail' })(
  PostDetailComponent
);

/*<Codenesium>
    <Hash>04ae1e76545a4766c394dd526d7319b7</Hash>
</Codenesium>*/