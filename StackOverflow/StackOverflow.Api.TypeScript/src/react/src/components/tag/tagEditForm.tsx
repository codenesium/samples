import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TagMapper from './tagMapper';
import TagViewModel from './tagViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
interface TagEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface TagEditComponentState {
  model?: TagViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class TagEditComponent extends React.Component<
  TagEditComponentProps,
  TagEditComponentState
> {
  state = {
    model: new TagViewModel(),
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
          let response = resp.data as Api.TagClientResponseModel;

          console.log(response);

          let mapper = new TagMapper();

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
        let model = values as TagViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      } 
	  else {
		  this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:TagViewModel) =>
  {  
    let mapper = new TagMapper();
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
            Api.TagClientRequestModel
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
              <label htmlFor='excerptPostId'>ExcerptPostId</label>
              <br />             
              {getFieldDecorator('excerptPostId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"ExcerptPostId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='tagName'>TagName</label>
              <br />             
              {getFieldDecorator('tagName', {
              rules:[{ required: true, message: 'Required' },
{ max: 150, message: 'Exceeds max length of 150' },
],
              
              })
              ( <Input placeholder={"TagName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='wikiPostId'>WikiPostId</label>
              <br />             
              {getFieldDecorator('wikiPostId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"WikiPostId"} /> )}
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

export const WrappedTagEditComponent = Form.create({ name: 'Tag Edit' })(TagEditComponent);

/*<Codenesium>
    <Hash>14e349a5c0e0c3fbbda9ccf63680e255</Hash>
</Codenesium>*/