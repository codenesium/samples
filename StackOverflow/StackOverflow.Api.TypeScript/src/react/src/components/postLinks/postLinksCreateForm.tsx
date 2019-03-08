import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostLinksMapper from './postLinksMapper';
import PostLinksViewModel from './postLinksViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { LinkTypesSelectComponent } from '../shared/linkTypesSelect'
	import { PostsSelectComponent } from '../shared/postsSelect'
	
interface PostLinksCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface PostLinksCreateComponentState {
  model?: PostLinksViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class PostLinksCreateComponent extends React.Component<
  PostLinksCreateComponentProps,
  PostLinksCreateComponentState
> {
  state = {
    model: new PostLinksViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false,
	submitting:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
	 this.setState({...this.state, submitting:true, submitted:false});
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as PostLinksViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:PostLinksViewModel) =>
  {  
    let mapper = new PostLinksMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PostLinks,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.PostLinksClientRequestModel
          >;
          this.setState({...this.state, submitted:true, submitting:false, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          if(error.response.data)
          {
			  let errorResponse = error.response.data as ActionResponse; 

			  errorResponse.validationErrors.forEach(x =>
			  {
				this.props.form.setFields({
				 [ToLowerCaseFirstLetter(x.propertyName)]: {
				  value:this.props.form.getFieldValue(ToLowerCaseFirstLetter(x.propertyName)),
				  errors: [new Error(x.errorMessage)]
				},
				})
			  });
		  }
          this.setState({...this.state, submitted:true, submitting:false, errorOccurred:true, errorMessage:'Error from API'});
        }
      ); 
  }
  
  render() {

    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        
    let message:JSX.Element = <div></div>;
    if(this.state.submitted)
    {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type='error' />;
      }
      else
      {
        message = <Alert message='Submitted' type='success' />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='creationDate'>Creation Date</label>
              <br />             
              {getFieldDecorator('creationDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Creation Date"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='linkTypeId'>Link Type</label>
                        <br />   
                        <LinkTypesSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.LinkTypes}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="linkTypeId"
                          required={true}
                          selectedValue={this.state.model!.linkTypeId}
                         />
                        </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='postId'>Post</label>
                        <br />   
                        <PostsSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Posts}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="postId"
                          required={true}
                          selectedValue={this.state.model!.postId}
                         />
                        </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='relatedPostId'>Related Post</label>
                        <br />   
                        <PostsSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Posts}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="relatedPostId"
                          required={true}
                          selectedValue={this.state.model!.relatedPostId}
                         />
                        </Form.Item>

			
           <Form.Item>
            <Button type="primary" htmlType="submit" loading={this.state.submitting} >
                {(this.state.submitting ? "Submitting..." : "Submit")}
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedPostLinksCreateComponent = Form.create({ name: 'PostLinks Create' })(PostLinksCreateComponent);

/*<Codenesium>
    <Hash>6fd3b97450a8f5fc60979a5cf3e70185</Hash>
</Codenesium>*/