import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TagsMapper from './tagsMapper';
import TagsViewModel from './tagsViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { PostsSelectComponent } from '../shared/postsSelect'
	interface TagsEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface TagsEditComponentState {
  model?: TagsViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class TagsEditComponent extends React.Component<
  TagsEditComponentProps,
  TagsEditComponentState
> {
  state = {
    model: new TagsViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false,
	submitting:false
  };

    componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Tags +
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
          let response = resp.data as Api.TagsClientResponseModel;

          console.log(response);

          let mapper = new TagsMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

		  this.props.form.setFieldsValue(mapper.mapApiResponseToViewModel(response));
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
 }
 
 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
	 this.setState({...this.state, submitting:true, submitted:false});
     this.props.form.validateFields((err:any, values:any) => {
     if (!err) {
        let model = values as TagsViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      } 
	  else {
		  this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:TagsViewModel) =>
  {  
    let mapper = new TagsMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Tags + '/' + this.state.model!.id,
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
            Api.TagsClientRequestModel
          >;
          this.setState({...this.state, submitted:true, submitting:false, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
		  let errorResponse = error.response.data as ActionResponse; 
		  if(error.response.data)
          {
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
              <label htmlFor='count'>Count</label>
              <br />             
              {getFieldDecorator('count', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"Count"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='excerptPostId'>Excerpt Post</label>
                        <br />   
                        <PostsSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Posts}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="excerptPostId"
                          required={true}
                          selectedValue={this.state.model!.excerptPostId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='tagName'>Tag Name</label>
              <br />             
              {getFieldDecorator('tagName', {
              rules:[{ required: true, message: 'Required' },
{ max: 150, message: 'Exceeds max length of 150' },
],
              
              })
              ( <Input placeholder={"Tag Name"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='wikiPostId'>Wiki Post</label>
                        <br />   
                        <PostsSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Posts}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="wikiPostId"
                          required={true}
                          selectedValue={this.state.model!.wikiPostId}
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

export const WrappedTagsEditComponent = Form.create({ name: 'Tags Edit' })(TagsEditComponent);

/*<Codenesium>
    <Hash>944eab55d4d068e80f43c81f14ce12f9</Hash>
</Codenesium>*/