import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductPhotoMapper from './productPhotoMapper';
import ProductPhotoViewModel from './productPhotoViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
interface ProductPhotoEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface ProductPhotoEditComponentState {
  model?: ProductPhotoViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class ProductPhotoEditComponent extends React.Component<
  ProductPhotoEditComponentProps,
  ProductPhotoEditComponentState
> {
  state = {
    model: new ProductPhotoViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

    componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ProductPhotoes +
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
          let response = resp.data as Api.ProductPhotoClientResponseModel;

          console.log(response);

          let mapper = new ProductPhotoMapper();

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
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as ProductPhotoViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:ProductPhotoViewModel) =>
  {  
    let mapper = new ProductPhotoMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.ProductPhotoes + '/' + this.state.model!.productPhotoID,
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
            Api.ProductPhotoClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
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
          this.setState({...this.state, submitted:true, errorOccurred:true, errorMessage:'Error from API'});
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
              <label htmlFor='largePhoto'>LargePhoto</label>
              <br />             
              {getFieldDecorator('largePhoto', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"LargePhoto"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='largePhotoFileName'>LargePhotoFileName</label>
              <br />             
              {getFieldDecorator('largePhotoFileName', {
              rules:[{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"LargePhotoFileName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='modifiedDate'>ModifiedDate</label>
              <br />             
              {getFieldDecorator('modifiedDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ModifiedDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='thumbNailPhoto'>ThumbNailPhoto</label>
              <br />             
              {getFieldDecorator('thumbNailPhoto', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ThumbNailPhoto"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='thumbnailPhotoFileName'>ThumbnailPhotoFileName</label>
              <br />             
              {getFieldDecorator('thumbnailPhotoFileName', {
              rules:[{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ThumbnailPhotoFileName"} /> )}
              </Form.Item>

			
          <Form.Item>
            <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedProductPhotoEditComponent = Form.create({ name: 'ProductPhoto Edit' })(ProductPhotoEditComponent);

/*<Codenesium>
    <Hash>83c5e4bd2362b2acd5ece89deaa14a91</Hash>
</Codenesium>*/